using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ammo : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] float lifespan = 0;
    Rigidbody rb;
    private void Start()
    {
        if(lifespan > 0) Destroy(gameObject, lifespan);
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward, ForceMode.VelocityChange);
        rb.AddRelativeForce(Vector3.left * speed, ForceMode.VelocityChange);


    }
}
