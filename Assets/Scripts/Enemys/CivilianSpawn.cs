using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianSpawn : MonoBehaviour
{
    
    public int current;
    int movingSpeed = 2;
    int firstLimit;
    int secondLimit;
    int thirdLimit;
    int lastLimit;

    public int actualSpawnPoint;

    public bool isDeath;
    private Animator animator;
    private Rigidbody rb;

    public void Awake()
    {
        actualSpawnPoint = Random.Range(0, 2);
    }
    public void Start()
    {
        
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isDeath = false;

        current = 0;
        firstLimit = Random.Range(-3, 3);
        secondLimit = Random.Range(-1, 3);
        thirdLimit = Random.Range(-3, 0);
        lastLimit = Random.Range(-4, 4);
    }

    public void Update()
    {
        Vector3 FirstLine = new Vector3(firstLimit, transform.position.y, -46.25f);
        Vector3 SecondLine = new Vector3(firstLimit, transform.position.y, -38.85f);
        Vector3 ThirdLine = new Vector3(secondLimit, transform.position.y, -35.5f);
        Vector3 FourthLine = new Vector3(secondLimit, transform.position.y, -31.35f);
        Vector3 FifthLine = new Vector3(firstLimit, transform.position.y, -27.25f);
        Vector3 SixthLine = new Vector3(firstLimit, transform.position.y, -22f);
        Vector3 SeventhLine = new Vector3(thirdLimit, transform.position.y, -17f);
        Vector3 EighthLine = new Vector3(thirdLimit, transform.position.y, -10.5f);
        Vector3 NinthLine = new Vector3(lastLimit, transform.position.y, 0.5f);

        Vector3[] Line1 = { FirstLine, SecondLine, ThirdLine, FourthLine, FifthLine, SixthLine, SeventhLine, EighthLine, NinthLine };
        Vector3[] Line2 = {SecondLine, ThirdLine, FourthLine, FifthLine, SixthLine, SeventhLine, EighthLine, NinthLine };
        /*Vector3[] Line3 = {ThirdLine, FourthLine, FifthLine, SixthLine, SeventhLine, EighthLine, NinthLine };
        Vector3[] Line4 = {FourthLine, FifthLine, SixthLine, SeventhLine, EighthLine, NinthLine };
        Vector3[] Line5 = {FifthLine, SixthLine, SeventhLine, EighthLine, NinthLine };
        Vector3[] Line6 = {SixthLine, SeventhLine, EighthLine, NinthLine };
        Vector3[] Line7 = {SeventhLine, EighthLine, NinthLine };
        Vector3[] Line8 = {EighthLine, NinthLine };
        Vector3[] LastLine = {NinthLine };*/

        if (actualSpawnPoint == 0)
        {
            PatrolingCharachters(Line1);
        }
        else if (actualSpawnPoint == 1)
        {
            PatrolingCharachters(Line2);
        }

    }

    void PatrolingCharachters(Vector3[] value )
    {

        Vector3 pointPos = value[current];

        if (isDeath == false)
        {
            if (transform.position != value[current])
            {
                transform.position = Vector3.MoveTowards(transform.position, value[current], movingSpeed * Time.deltaTime);
                transform.LookAt(pointPos, Vector3.up);
            }
            else
            {
                current = (current + 1);
            }

            if (current == value.Length)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            rb.freezeRotation = false;
            animator.SetBool("isDeath", true);
        }
    }
    
}
