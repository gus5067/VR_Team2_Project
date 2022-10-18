using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetector : MonoBehaviour
{
    [SerializeField]
    public GameObject target;
    [Header("View Detector")]
    [SerializeField]
    private float viewRadius;
    [SerializeField]
    private LayerMask targetMask;

    public void FindTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (targets.Length < 1)
        {
            target = null;
            return;
        }
        else
        {
            target = targets[0].gameObject;
            Vector3 targetPos = target.transform.position;
            this.transform.LookAt(new Vector3(targetPos.x, 0, targetPos.z));
        }
    }
}
