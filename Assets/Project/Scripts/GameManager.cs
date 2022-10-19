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
                    zombie.GetComponent<Zombie>()?.GetDamage(5);
                }
            }
        }

        Collider[] explodes = Physics.OverlapSphere(player.transform.position + Vector3.up, 15f, 1 << 12);
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Æø¹ß¹°¿¡ µ¥¹ÌÁö ÁÜ");


            if (explodes.Length > 0)
            {
                foreach (Collider explode in explodes)
                {
                    explode.GetComponent<IDamageable>()?.GetDamage(20);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(player.transform.position + Vector3.up, 15f);
    }

}
