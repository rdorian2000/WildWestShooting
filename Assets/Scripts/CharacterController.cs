using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float xMoveRange = 4f;

    private float mouseRotationX;
    private float mouseRotationY;
    private float mouseRotationXLimit = 30f;
    private float mouseRotationYLimit = 75;
    public float mouseSensitivity = 15f;

    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
        MouseLookAround();
        ShootSpawn();
    }

    void MoveRight()
    {
       
        if(transform.position.x < -xMoveRange)
        {
            transform.position = new Vector3(-xMoveRange, 0, 0);
        }

        if (transform.position.x > xMoveRange)
        {
            transform.position = new Vector3(xMoveRange, 0, 0);
        }

        transform.position = new Vector3(transform.position.x, 0, 0);

        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * moveSpeed);
    }

    void MouseLookAround()
    {
        //Horizontal mouse moving
        mouseRotationY += Input.GetAxis("Mouse X") * mouseSensitivity;
        if (mouseRotationY < -mouseRotationYLimit)
        {
            mouseRotationY = -mouseRotationYLimit;
        }else if (mouseRotationY > mouseRotationYLimit)
        {
            mouseRotationY = mouseRotationYLimit;
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
        Cursor.lockState = CursorLockMode.Locked;
    }

    void ShootSpawn() 
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            
        }
    }

}
