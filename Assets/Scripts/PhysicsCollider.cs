using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    string status;
    Vector3 contact, normal;
    [SerializeField] GameObject explosion;
    private void OnCollisionEnter(Collision collision)
    {
        status = "collision enter: " + collision.gameObject.name;
        contact = collision.GetContact(0).point;
        normal = collision.GetContact(0).normal;
        if(explosion != null)
        {
            //explosion.transform.position = contact;
            Instantiate(explosion, contact, Quaternion.LookRotation(normal));
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        status = "collision stay: " + collision.gameObject.name;
    }
    private void OnCollisionExit(Collision collision)
    {
        status = "collision exit: " + collision.gameObject.name;
    }
    private void OnTriggerEnter(Collider other)
    {
        status = "trigger enter: " + other.gameObject.name;
    }
    private void OnTriggerStay(Collider other)
    {
        status = "trigger stay: " + other.gameObject.name;

    }
    private void OnTriggerExit(Collider other)
    {
        status = "trigger exit: " + other.gameObject.name;

    }
    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(contact, 0.5f);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(contact, contact + normal);
    }

}