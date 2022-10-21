using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BusSpeedController : MonoBehaviour
{
    private NavMeshAgent bus;

    [SerializeField, Range(0f, 10f)]
    private float speed;
    public float Speed
    {
        get { return speed; }
        set
        {
            if (value <= 0)
            {
                speed = 0;
            }
            else
            {
                speed = value;
            }
        }
    }
    private void Awake()
    {
        bus = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        bus.speed = Speed;
    }
}
