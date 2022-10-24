using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusTest : MonoBehaviour
{
    [SerializeField]
    private Transform[] destinations;

    private int i = 0;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            ChangeDestination(i % 4);
        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            i++;
            Debug.Log(i);
        }
    }

    private void ChangeDestination(int i)
    {
        transform.position = Vector3.MoveTowards(transform.position, destinations[i].position, 4f * Time.deltaTime);
    }
}
