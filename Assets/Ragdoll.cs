using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(RagdollRoutine());
    }

    IEnumerator RagdollRoutine()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);

    }
}
