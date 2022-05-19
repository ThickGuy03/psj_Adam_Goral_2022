using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContoller : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float HorizontalInput;
    private float VerticalInput;
    private float currentsteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontleftwheelColider;
    [SerializeField] private WheelCollider frontrightwheelColider;
    [SerializeField] private WheelCollider backleftwheelColider;
    [SerializeField] private WheelCollider backrightwheelColider;

    [SerializeField] private Transform frontleftwheelTransform;
    [SerializeField] private Transform frontrightwheelTransform;
    [SerializeField] private Transform backleftwheelTransform;
    [SerializeField] private Transform backrightwheelTransform;

    private void Update()
    {
      GetInput();
      HandleMotor();
      HandleSteering();
      UpdateWheels();
    }
    private void HandleMotor()
    {
        frontleftwheelColider.motorTorque = VerticalInput * (motorForce*1000000);
        frontrightwheelColider.motorTorque = VerticalInput * (motorForce * 1000000);
        currentbreakForce = isBreaking ? breakForce : 0f;
        if(isBreaking)
        {
            ApplyBreaking();
        }
    }
    private void ApplyBreaking()
    {
        frontleftwheelColider.brakeTorque = currentbreakForce;
        frontrightwheelColider.brakeTorque = currentbreakForce;
        backleftwheelColider.brakeTorque = currentbreakForce;
        backrightwheelColider.brakeTorque = currentbreakForce;
    }
    private void GetInput()
    {
        HorizontalInput = Input.GetAxis(HORIZONTAL);
        VerticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleSteering()
    {
        currentsteerAngle = maxSteerAngle * HorizontalInput;
        frontleftwheelColider.steerAngle = currentsteerAngle;
        frontrightwheelColider.steerAngle = currentsteerAngle;
    }
    private void UpdateWheels()
    {
        UpdateSingleWheel(frontleftwheelColider, frontleftwheelTransform);
        UpdateSingleWheel(frontrightwheelColider, frontrightwheelTransform);
        UpdateSingleWheel(backleftwheelColider, backleftwheelTransform);
        UpdateSingleWheel(backrightwheelColider, backrightwheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelColider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelColider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
