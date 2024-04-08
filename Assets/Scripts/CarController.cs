using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using static CarController;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using System;
using UnityEngine.Windows;
public class CarController : MonoBehaviour
{
    [System.Serializable]
    public struct Wheel
    {
        public WheelCollider collider;
        public Transform transform;
    }
    [System.Serializable]
    public struct Axle
    {
        public Wheel leftWheel;
        public Wheel rightWheel;
        public bool isMotor;
        public bool isSteering;
    }
    [SerializeField] Axle[] axles;
    [SerializeField] float maxMotorTorque;
    [SerializeField] float maxSteeringAngle;
    public void FixedUpdate()
    {
        float motor = UnityEngine.Input.GetAxis("Vertical") * maxMotorTorque;//input vertical axis * max torque
        float steering = UnityEngine.Input.GetAxis("Horizontal") * maxSteeringAngle;//input horizontal axis times max steering angle
    foreach (Axle axle in axles)
        {
            if (axle.isSteering)
            {
                axle.leftWheel.collider.steerAngle = steering;
                axle.rightWheel.collider.steerAngle = steering;
            }
            if (axle.isMotor)
            {
                axle.leftWheel.collider.motorTorque = motor;
                axle.rightWheel.collider.motorTorque = motor;
            }
            UpdateWheelTransform(axle.leftWheel);
            UpdateWheelTransform(axle.rightWheel);
        }
    }
    public void UpdateWheelTransform(Wheel wheel)
    {
        wheel.collider.GetWorldPose(out Vector3 position, out Quaternion rotation);

        wheel.transform.position = position;
        wheel.transform.rotation = rotation;
    }
}