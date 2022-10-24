using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBumper : MonoBehaviour
{
    private int layerNum;
    private void Start()
    {
        layerNum = LayerMask.NameToLayer("Monster");
        Debug.Log(layerNum);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == layerNum)
        {
            IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
            damageable?.GetDamage(200);
        }
    }
}
