using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    Plane plane;
    Vector3 dir;

    private void Start()
    {
        plane = GetComponent<Plane>();
        //transform.LookAt(plane.destination.transform);
        Destroy(gameObject, 5f);

    }
    private void Update()
    {
        //Debug.Log(dir);

        transform.Translate(Vector3.forward * speed);
            
    }
}