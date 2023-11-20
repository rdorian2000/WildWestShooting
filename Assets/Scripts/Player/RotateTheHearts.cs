using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTheHearts : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Update()
    {
        gameObject.transform.Rotate(0, 3, 0);
    }
}
           