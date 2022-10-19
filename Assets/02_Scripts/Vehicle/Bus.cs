using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bus : MonoBehaviour
{
    // public float speed = 10f;
    NavMeshAgent agent;
    private Transform target;
    private int wavepointIndex = 0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        target = Waypoints.points[0];
    }
    void Update()
    {
        //Vector3 dir = target.position - transform.position;
        // transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //Debug.Log("..");
        //Debug.Log(target.position);
        agent.SetDestination(target.position);
        
        //agent.SetDestination(target.position);
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }

        
    }

    void GetNextWayPoint()
    {
        wavepointIndex++;
        if (wavepointIndex >= Waypoints.points.Length)
        {
            wavepointIndex = 0;
        }
        target = Waypoints.points[wavepointIndex];
    }
}
