using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class RigidBodyController : MonoBehaviour
{

    [SerializeField] float speed = 1;
    [SerializeField] ForceMode forceMode = ForceMode.Force;
    [SerializeField] Space space = Space.World;
    Rigidbody rb;
    Vector3 force;
    Vector3 torque;
    private void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }
    void Update()
    {
        Vector3 direction = Vector3.zero;
        float rotation = 0;

        if (space == Space.World) direction.x = Input.GetAxis("Horizontal");
        else if (space == Space.Self)
        {
            rotation = Input.GetAxis("Horizontal");
        }
        direction.z = Input.GetAxis("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);

        force = direction * speed;
        torque = Vector3.up * rotation * speed;

        //transform.rotation *= Quaternion.Euler(0, rotation * speed, 0);
        //direction = transform.rotation * direction;
        //transform.Translate(direction * speed * Time.deltaTime, space);
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(force, forceMode);
        rb.AddTorque(torque, forceMode);
    }
    // RGB
    // XYZ
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);
    }
}
