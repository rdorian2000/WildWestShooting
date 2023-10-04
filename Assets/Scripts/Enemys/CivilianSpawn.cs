using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianSpawn : MonoBehaviour
{
    //public Transform[] spawnPoints;
    public int current;
    public float movingSpeed;
    public float rotationSpeed;
    int firstLimit;
    int secondLimit;
    int thirdLimit;
    int lastLimit;
    public void Start()
    {
        current = 0;
        firstLimit = Random.Range(-3, 3);
        secondLimit = Random.Range(-1, 3);
        thirdLimit = Random.Range(-3, 0);
        lastLimit = Random.Range(-4, 4);

    }

    public void Update()
    {
        Vector3 FirstLine = new Vector3(firstLimit, transform.position.y, -46.25f);
        Vector3 SecondLine = new Vector3(firstLimit, transform.position.y, -37f);
        Vector3 ThirdLine = new Vector3(secondLimit, transform.position.y, -35.5f);
        Vector3 FourthLine = new Vector3(secondLimit, transform.position.y, -31.35f);
        Vector3 FifthLine = new Vector3(firstLimit, transform.position.y, -27.25f);
        Vector3 SixthLine = new Vector3(firstLimit, transform.position.y, -22f);
        Vector3 SeventhLine = new Vector3(thirdLimit, transform.position.y, -17f);
        Vector3 EighthLine = new Vector3(thirdLimit, transform.position.y, -10.5f);
        Vector3 NinthLine = new Vector3(lastLimit, transform.position.y, 0.5f);

        Vector3[] lines = { FirstLine, SecondLine, ThirdLine, FourthLine, FifthLine, SixthLine, SeventhLine, EighthLine, NinthLine };

        Vector3 pointPos = lines[current];
        if (transform.position != lines[current])
        {
            transform.position = Vector3.MoveTowards(transform.position, lines[current], movingSpeed * Time.deltaTime);
            transform.LookAt(pointPos, Vector3.up);
        }
        else
        {
            current = (current + 1);
        }

        if (current == lines.Length)
        {
            Destroy(gameObject);
        }

    }
}
