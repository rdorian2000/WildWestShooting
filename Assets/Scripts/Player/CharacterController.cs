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

    public bool backward = false;

    private int maxWeaponAmmo = 5;
    [SerializeField]private int currentWeaponAmmo;
    private float reloadTime = 3.25f;
    public bool isReloding;

    public ParticleSystem gunShotSmoke;


    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gunShotSmoke.Stop();
        isReloding = false;
        backward = true;       
        currentWeaponAmmo = maxWeaponAmmo;
    }

    void Update()
    {
        if (PauseMenu.GameIsPaused ==false)
        {
            MoveAndFirstPersonCameraController();
            BulletSpawn();
            PlayerReloadWeapon();
        }       
                     
    }   

    //Mozgás sík megadása event szerint.
    void MoveAndFirstPersonCameraController()
    {

        if (backward)
        {
            HorizontalMouseMove(105f, 255f);  //Backward (Train)
            MoveOnXAxes(4f, 0f, -4f);         //Backward (Train)
        }
        
        //Vertical mouse move.
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

    //Camera moves with the mouse.
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

    //The player moves on the x axes.
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
    
    //Bullet spawn.
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
        //Player shoots the enemy.
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentWeaponAmmo != 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            AudioManagerScript.Instance.PlaySound("ShootSound");
            Destroy(bullet, 5f);
            revolverRevolve.transform.Rotate(Vector3.forward,90);
            WhenShoot();
            Shoot();
            gunShotSmoke.Play();
            currentWeaponAmmo--;
        }

    }
    //When the player shoots the enemy, and the enemy has rigidbody, he becomes damage.
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) 
        {                    
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

    //When the ammo runs out, the gun automatically reloads.
    IEnumerator AutomateReloadWeapon()
    {
        isReloding = true;
        WhenReload();
        AudioManagerScript.Instance.PlaySound("RevolverReloadSound");
        yield return new WaitForSeconds(reloadTime);       
        currentWeaponAmmo = maxWeaponAmmo;
        AudioManagerScript.Instance.StopSound("RevolverReloadSound");
        isReloding = false;
    }

    //When the player has not full ammo, he can reload with "R".
    void PlayerReloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentWeaponAmmo!=maxWeaponAmmo && isReloding==false)
        {
            StartCoroutine(AutomateReloadWeapon());
        }

    }
    //Rotate the revolve on the HUD, when the player shoots.
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
    //Rotate the revolve on the HUD, when the player reloads.
    void WhenReload()
    {      
        if (hudRevolveReload != null)
        {
            hudRevolveReload();       
        }       
    }

    

}
