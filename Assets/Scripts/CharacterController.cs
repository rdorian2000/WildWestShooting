using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
    public static event Action hudRevolveShoot;
    public static event Action hudRevolveReload;

    private GameManager gameManager;

    private float moveSpeed = 5f;
    private float mouseRotationX;
    private float mouseRotationY;
    private float mouseRotationXLimit = 30f;
    private float mouseSensitivity = 5f;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public GameObject revolverRevolve;
    public GameObject hudGUIrevolve;

    public Camera fpsCam;
    public float range = 100f;
    public GameObject bloodDropEffect;

    public bool forward;
    public bool backward;
    public bool right;
    public bool left;

    private int maxWeaponAmmo = 5;
    [SerializeField]private int currentWeaponAmmo;
    private float reloadTime = 3f;
    public bool isReloding;

    public ParticleSystem gunShotSmoke;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gunShotSmoke.Stop();
        isReloding = false;
        forward = false;
        backward = true;
        right = false;
        left = false;
        
        currentWeaponAmmo = maxWeaponAmmo;
    }

    void Update()
    {
        MoveAndFirstPersonCameraController();
        BulletSpawn();
        PlayerReloadWeapon();
        MouseCursorLock();
        
    }   

    //Mozgás sík megadása event szerint.
    void MoveAndFirstPersonCameraController()
    {
        //Horizontal mouse moving
        if (forward)
        {
            HorizontalMouseMove(-75f, 75f);   //Forward (City)
            MoveOnXAxes(10f, 0.825f, 6.3f);   //Forward (City)

        }
        if (backward)
        {
            HorizontalMouseMove(105f, 255f);  //Backward (Train)
            MoveOnXAxes(4f, 0f, -4f);         //Backward (Train)
        }
        if (right)
        {
            HorizontalMouseMove(15f, 165f);   //Right (Road)
            MoveOnZAxes(0f, 0f, 3f);          //Right (Road)
        }
        if (left)
        {
            HorizontalMouseMove(-165f, -15f);   //Left (Road)
            MoveOnZAxes(0f, 0f, 3f);            //Left (Road)
        }
        
        //Vertical mouse moving
        mouseRotationX += Input.GetAxis("Mouse Y") * (-1) * mouseSensitivity;
        if (mouseRotationX < -mouseRotationXLimit)
        {
            mouseRotationX = -mouseRotationXLimit;
        }
        else if (mouseRotationX > mouseRotationXLimit)
        {
            mouseRotationX = mouseRotationXLimit;
        }

        transform.localEulerAngles = new Vector3(mouseRotationX, mouseRotationY, 0);
        
    }

    //Kamera mozgatása egérrel vízszintesen.
    void HorizontalMouseMove(float limitDown, float limitUp)
    {
        
        mouseRotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
        if (mouseRotationY < limitDown)
        {
            mouseRotationY = limitDown;
        }
        else if (mouseRotationY > limitUp)
        {
            mouseRotationY = limitUp;
        }
    }

    //Mozgás sík megadása. (Forward,Backward)
    void MoveOnXAxes(float xMoveRange, float yMoveRange, float zMoveRange)
    {

        if (transform.position.x < -xMoveRange)
        {
            transform.position = new Vector3(-xMoveRange, yMoveRange, zMoveRange);
        }

        if (transform.position.x > xMoveRange)
        {
            transform.position = new Vector3(xMoveRange, yMoveRange, zMoveRange);
        }

        transform.position = new Vector3(transform.position.x, yMoveRange, zMoveRange);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * moveSpeed);
    }
    //Mozgás sík megadása. (Right,Left)
    void MoveOnZAxes(float xMoveRange, float yMoveRange, float zMoveRange)
    {

        if (transform.position.z < -zMoveRange)
        {
            transform.position = new Vector3(xMoveRange, yMoveRange, -zMoveRange);
        }

        if (transform.position.z > zMoveRange)
        {
            transform.position = new Vector3(xMoveRange, yMoveRange, zMoveRange);
        }

        transform.position = new Vector3(xMoveRange, yMoveRange, transform.position.z);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * moveSpeed);
    }
    //Lõszer spawn a fegyverbõl.
    void BulletSpawn()
    {
        if (isReloding)
        {
            return;
        }

        if (currentWeaponAmmo <= 0)
        {
            StartCoroutine(AutomateReloadWeapon());
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentWeaponAmmo != 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            Destroy(bullet, 5f);
            revolverRevolve.transform.Rotate(Vector3.forward,90);
            WhenShoot();
            Shoot();
            gunShotSmoke.Play();
            currentWeaponAmmo--;
        }

    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);
            
            EnemyHealPoints target = hit.transform.GetComponent<EnemyHealPoints>();
            if (target != null)
            {
                target.TakeDamage();
            }

            if(hit.rigidbody != null)
            {
                GameObject bloodGameObecjt = Instantiate(bloodDropEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(bloodGameObecjt, 2f);
            }

            if (hit.transform.tag=="Enemy" || hit.transform.tag=="PianoMan")
            {
                gameManager.AddScore(1);
            }

            if (hit.transform.tag == "Civilian")
            {
                gameManager.AddScore(-3);
            }

        }
    }

    //Ha elfogy a lõszer autómata újratöltés.
    IEnumerator AutomateReloadWeapon()
    {
        isReloding = true;
        WhenReload();
        Debug.Log("ReloadTimeBaby");

        yield return new WaitForSeconds(reloadTime);

        Debug.Log("You can shoot!");
        currentWeaponAmmo = maxWeaponAmmo;
        isReloding = false;
    }

    //Ha még nem fogyott el minden lõszer, de újra akar tölteni a játékos.
    void PlayerReloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentWeaponAmmo!=maxWeaponAmmo)
        {
            StartCoroutine(AutomateReloadWeapon());
        }

    }

    //Kurzor képernyõ közepére zárolása.
    void MouseCursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void WhenShoot()
    {
        if (currentWeaponAmmo != 0)
        {
            if (hudRevolveShoot != null)
            {
                hudRevolveShoot();
            }
        }
    }

    void WhenReload()
    {      
        if (hudRevolveReload != null)
        {
            hudRevolveReload();       
        }
        
    }

    

}
