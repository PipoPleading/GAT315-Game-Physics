using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovement : MonoBehaviour
{
    [SerializeField] Vector3 force;
    [SerializeField] ForceMode mode;
    [SerializeField] Vector3 torque;
    [SerializeField] ForceMode torqueMode;
    [SerializeField] KeyCode jumpKey;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            //includes time delta
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);

            //relative to it's world position
            //rb.AddRelativeForce(force, mode);

        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //includes time delta
            rb.AddForce(force, mode);
            rb.AddTorque(torque, mode);

            //relative to it's world position
            //rb.AddRelativeForce(force, mode);

        }
    }
}
