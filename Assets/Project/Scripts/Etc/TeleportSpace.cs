using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSpace : MonoBehaviour
{
    [SerializeField]
    public Vector3 posOffset;

    [SerializeField]
    public Vector3 rotOffset;

    public bool isTest;

    public void Test()
    {
        Debug.Log(gameObject.name);
        isTest = !isTest;
    }


}
