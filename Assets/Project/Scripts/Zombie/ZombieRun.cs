using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRun : Zombie
{
    protected override void Die()
    {
        ObjectPooling.poolDic["ZombieRun_Ragdoll"].GetPool(transform.position, transform.rotation);
        ObjectPooling.poolDic["ZombieRun"].ReturnPool(this.gameObject);
    }
}
