using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject GameObject;
    public KeyCode KeyCode;

    void Update()
    {
        if(Input.GetKey(KeyCode))
        {
            Instantiate(GameObject, transform.position, transform.rotation);
        }
    }
}
