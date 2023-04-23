using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [Header("Plane Stats")]

    [SerializeField]
    float throttleIncrement = 0.1f;
    [SerializeField]
    float maxThrust = 200f;
    [SerializeField] 
    float responsiveness = 10f;

    [SerializeField] private GameObject respawnPoint;
    

    private bool _hasControl = true;

    public float throttle;
    private float yaw;
    private float pitch;
    private float roll;

    private float responseModifier
    {
        get { return (rb.mass / 10f) * responsiveness; }
        
    }

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;

        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }

    public void SetMovementToZero()
    {
        throttle = 0;
        yaw = 0;
        pitch = 0;
        roll = 0;
    }

    void Update()
    {
        HandleInputs();

    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);

    }

    private void OnCollisionEnter(Collision other)
    {
        throttle = 0;
        yaw = 0;
        roll = 0;
        pitch = 0;
        this.transform.position = respawnPoint.transform.position;
    }
}
