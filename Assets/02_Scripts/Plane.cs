using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject bus;
    public GameObject fireLocation;
    public GameObject nuke;
    public bool isDelay = false;
    public float delayTime = 2f;

    void Start()
    {
        //fireLocation.transform.position = Vector3.zero;
        bus = GameObject.Find("Bus");
        //destination.transform.localPosition = new Vector3(bus.transform.position.x, bus.transform.position.y, bus.transform.position.z + 40f);

        //firePoint.transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 40f);
        //Instantiate(firePoint, firePoint.transform.localPosition, Quaternion.identity);
        
        //Debug.Log(fireLocation.transform.localPosition);
    }

    void Update()
    {
        //destination = bus.transform.Find("PlaneMoveDirection").gameObject;
        fireLocation = bus.transform.Find("FireLocation").gameObject;

        //destination.transform.position += bus.transform.position;
        //Debug.Log(destination.transform.position);
        if (Vector3.Distance(transform.position, fireLocation.transform.position) <= 15f)
        {
            if(!isDelay)
            {
                isDelay = true;
                StartCoroutine("Fire");
            }
        }
    }
    IEnumerator Fire()
    {
        Instantiate(nuke, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
        //destination.transform.position = Vector3.zero;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(fireLocation.transform.position, 50);
    }
    
}