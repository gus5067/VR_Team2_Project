using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_FlameMove : MonoBehaviour
{
    [SerializeField]
    private Transform[] wayPoints;  // 이동할 타겟들
    [SerializeField]
    private float waitTime;
    [SerializeField]
    private float moveSpeed;
    
    private int wayPointCount;      // 2
    private int currentIndex = 0;   // 0

    private void OnEnable()
    {
        
        currentIndex = 0;
        wayPointCount = wayPoints.Length;
        transform.position = wayPoints[currentIndex].position;

        currentIndex++;
        StartCoroutine("MoveTo");
    }

    private IEnumerator MoveTo()
    {
        while( true )
        {
            yield return StartCoroutine("Movement");

            yield return new WaitForSeconds(waitTime);

            if(currentIndex < wayPointCount -1)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }
        }
    }
    private IEnumerator Movement()
    {
        while(true)
        {
            Vector3 moveDirection = (wayPoints[currentIndex].position - transform.position).normalized;
            
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            if(currentIndex == 0)
            {
                transform.Rotate(new Vector3(0f, -60f, 0f) * Time.deltaTime);
            }
            if(currentIndex == 1)
            {
                transform.Rotate(new Vector3(0f, 60f, 0f) * Time.deltaTime);
            }
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.05f )
            {
                transform.position = wayPoints[currentIndex].position;

                break;
            }
            yield return null;
        }
    }    
}