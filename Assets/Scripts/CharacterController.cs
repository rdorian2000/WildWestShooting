using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float moveSpeed = 5f;

    [SerializeField]private float mouseRotationX;
    [SerializeField] private float mouseRotationY;
    private float mouseRotationXLimit = 30f;
    public float mouseSensitivity = 50f;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    public bool forward;
    public bool backward;
    public bool right;
    public bool left;

    public int maxWeaponAmmo = 6;
    public int currentWeaponAmmo;
    public float reloadTime = 5f;
    public bool isReloding = false;

    public ParticleSystem gunShotSmoke;

    // Start is called before the first frame update
    void Start()
    {
        gunShotSmoke.Stop();
        forward = false;
        backward = true;
        right = false;
        left = false;
        
        currentWeaponAmmo = maxWeaponAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndFirstPersonCameraController();
        BulletSpawn();
        MouseCursorLock();
    }

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

    void BulletSpawn()
    {
        if (isReloding)
        {
            return;
        }

        if (currentWeaponAmmo <= 0)
        {
            StartCoroutine(ReloadWeapon());
            return;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && currentWeaponAmmo !=0)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            gunShotSmoke.Play();
            currentWeaponAmmo--;
        }
    }

    IEnumerator ReloadWeapon()
    {
        isReloding = true;
        Debug.Log("ReloadTimeBaby");

        yield return new WaitForSeconds(reloadTime);

        Debug.Log("You can shoot!");
        currentWeaponAmmo = maxWeaponAmmo;
        isReloding = false;
    }

    void MouseCursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

}
