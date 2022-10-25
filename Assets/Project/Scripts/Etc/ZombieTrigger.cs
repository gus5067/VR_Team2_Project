using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTrigger : MonoBehaviour
{

    [SerializeField]
    private Transform[] spawnPos;

    [SerializeField]
    private int spawnNum;

    [SerializeField ,Range(0f, 10f)]
    private float spawnTime;

    [SerializeField, Range(1f, 10f)]
    private float spawnRange;

    [SerializeField]
    private bool isZombieRun;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bus" )
        {
            InvokeRepeating("ZombieSpawn", 0.2f, spawnTime);
            Invoke("StopSpawn", spawnNum * spawnTime + 0.3f);
            gameObject.SetActive(false);
        }
    }

    private void ZombieSpawn()
    {
        foreach (Transform t in spawnPos)
        {
            ObjectPooling.poolDic["Zombie"].GetPool(t.position + new Vector3(Random.Range(0f, spawnRange), 0, Random.Range(0f, spawnRange)), Quaternion.Euler(0, Random.Range(0f, 120f), 0));
            if (Random.Range(0, 11) > 6 && isZombieRun)
            {
                ObjectPooling.poolDic["ZombieRun"].GetPool(t.position + new Vector3(Random.Range(0f, spawnRange), 0, Random.Range(0f, spawnRange)), Quaternion.Euler(0, Random.Range(0f, 120f), 0));
            }
        }
    }

    private void StopSpawn()
    {
        CancelInvoke("ZombieSpawn");
    }


}
