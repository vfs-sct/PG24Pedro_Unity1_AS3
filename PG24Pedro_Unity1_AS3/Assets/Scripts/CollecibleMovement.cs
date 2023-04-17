using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecibleMovement : MonoBehaviour
{

    [SerializeField] private Vector3 rotateSpeed;
    
    void Update()
    {
        transform.Rotate(rotateSpeed * Time.deltaTime);

    }
}
