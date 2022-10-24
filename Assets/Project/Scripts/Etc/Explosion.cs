using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("TurnOffVfx", 0.8f);
    }

    private void TurnOffVfx()
    {
        gameObject.SetActive(false);
    }

}
