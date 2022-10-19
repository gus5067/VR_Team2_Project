using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Vehicle : MonoBehaviour
{
    NavMeshAgent agent;
    private Transform target;
    private int wavepointIndex = 0;
    public GameObject plane;
    public GameObject planeSpawnPoint;
    public GameObject fireFront;
    public GameObject fireBack;

    void Start()
    {
        //Debug.Log(target);
        agent = GetComponent<NavMeshAgent>();
        target = Waypoints.points[0];
    }

    void Update()
    {
        //Debug.Log(target.position);
        agent.SetDestination(target.position);

        if (Vector3.Distance(transform.position, target.position) <= 1f)
        {
            GetNextWayPoint();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(plane, planeSpawnPoint.transform.position, transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Skill_Fire());
        }


    }

    IEnumerator Skill_Fire()
    {
        fireFront.SetActive(true);
        fireBack.SetActive(true);
        yield return new WaitForSeconds(3f);
        fireFront.SetActive(false);
        fireBack.SetActive(false);

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