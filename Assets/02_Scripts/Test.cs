using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject nukeEffect;
    void Awake()
    {
        Instantiate(nukeEffect, transform.position, Quaternion.identity);
    }
}
