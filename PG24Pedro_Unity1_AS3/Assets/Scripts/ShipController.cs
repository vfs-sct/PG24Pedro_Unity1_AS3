using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    float FlySpeed = 15;
    
    [SerializeField]
    float YawAmount = 120;
    
    private float yaw;
    private float pitch;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        
        yaw += horizontalInput * YawAmount * Time.deltaTime;
         pitch = Mathf.Lerp(0, 20, Math.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        
        transform.localRotation = Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch);

    }
}
