using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    public bool FindTarget()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        if (targets.Length < 1)
        {
            target = null;
            return target != null;
        }
        else
        {
            target = targets[0].gameObject;
            Vector3 targetPos = target.transform.position;
            this.transform.LookAt(new Vector3(targetPos.x, this.transform.position.y, targetPos.z));
            return target != null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}
