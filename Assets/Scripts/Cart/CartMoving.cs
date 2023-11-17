using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMoving : MonoBehaviour
{
    public int rotateSpeed;
    private void Start()
    {
        rotateSpeed = 10;
        this.transform.Translate(Vector3.forward * 5f);
    }
    void Update()
    {
        
    }



}
