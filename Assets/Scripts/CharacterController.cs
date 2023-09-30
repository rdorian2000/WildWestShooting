using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float moveSpeed = 5f;

    private float mouseRotationX;
    private float mouseRotationY;
    private float mouseRotationXLimit = 30f;
    private float mouseSensitivity = 5f;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    public bool forward;
    public bool backward;
    public bool right;
    public bool left;

    private int maxWeaponAmmo = 6;
    [SerializeField]private int currentWeaponAmmo;
    private float reloadTime = 2.5f;
    private bool isReloding = false;

    public ParticleSystem gunShotSmoke;


    void Start()
    {
        gunShotSmoke.Stop();
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
    //Mozg�s s�k megad�sa event szerint.
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

    //Kamera mozgat�sa eg�rrel v�zszintesen.
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

    //Mozg�s s�k megad�sa. (Forward,Backward)
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
    //Mozg�s s�k megad�sa. (Right,Left)
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
    //L�szer spawn a fegyverb�l.
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
            Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            gunShotSmoke.Play();
            currentWeaponAmmo--;
        }

    }

    //Ha elfogy a l�szer aut�mata �jrat�lt�s.
    IEnumerator AutomateReloadWeapon()
    {
        isReloding = true;
        Debug.Log("ReloadTimeBaby");

        yield return new WaitForSeconds(reloadTime);

        Debug.Log("You can shoot!");
        currentWeaponAmmo = maxWeaponAmmo;
        isReloding = false;
    }

    //Ha m�g nem fogyott el minden l�szer, de �jra akar t�lteni a j�t�kos.
    void PlayerReloadWeapon()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentWeaponAmmo!=maxWeaponAmmo)
        {
            StartCoroutine(AutomateReloadWeapon());
        }
        else
        {
            Debug.Log("Weapon is full");
        }
    }

    //Kurzor k�perny� k�zep�re z�rol�sa.
    void MouseCursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

}
