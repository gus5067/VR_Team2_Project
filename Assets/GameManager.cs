using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void Update()
    {
        Collider[] zombies = Physics.OverlapSphere(player.transform.position + Vector3.up, 15f, 1 << 9);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("µ¥¹ÌÁö ÁÜ");
            

            if(zombies.Length > 0)
            {
                foreach(Collider zombie in zombies)
                {
                    zombie.GetComponent<Zombie>()?.GetDamage(20);
                }
            }
            //foreach (Zombie zombie in zombies)
            //{
            //    if (zombie is IDamageable)
            //    {
            //        zombie.GetDamage(20);
            //    }
            //}
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(player.transform.position + Vector3.up, 15f);
    }

}
