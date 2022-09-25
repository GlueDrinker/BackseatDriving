using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBreakForce;
    private bool isBreaking;

    [SerializeField] private WheelCollider FLWheelCollider;
    [SerializeField] private WheelCollider FRWheelCollider;
    [SerializeField] private WheelCollider RLWheelCollider;
    [SerializeField] private WheelCollider RRWheelCollider;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteeringAngle;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
    }

    private void HandleMotor()
    {
        RLWheelCollider.motorTorque = -verticalInput * motorForce;
        RRWheelCollider.motorTorque = -verticalInput * motorForce;
        currentBreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        FLWheelCollider.brakeTorque = currentBreakForce;
        FRWheelCollider.brakeTorque = currentBreakForce;
        RLWheelCollider.brakeTorque = currentBreakForce;
        RRWheelCollider.brakeTorque = currentBreakForce;
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleSteering()
    {
        currentSteerAngle = maxSteeringAngle * horizontalInput;
        FLWheelCollider.steerAngle = currentSteerAngle;
        FRWheelCollider.steerAngle = currentSteerAngle;
    }

}
