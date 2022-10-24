using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour, IDamageable
{
    [SerializeField]
    private GameObject vfx;

    [SerializeField, Range(0f, 10f)]
    private float range;

    [SerializeField, Range(50, 200)]
    private float damage;

    [SerializeField, Range(1000, 10000)]
    private float explosionPower;


    [SerializeField]
    private float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            if (value <= 0)
            {
                Explosion();
            }
            else
            {
                hp = value;
                Debug.Log("Æø¹ß¹° Ã¼·Â : " + hp);
            }

        }
    }
    public void GetDamage(float damage)
    {
        Hp -= damage;
    }

    private void Explosion()
    {
        vfx.SetActive(true);
        Collider[] targets = Physics.OverlapSphere(transform.position, range, 1 << 9);
        if (targets.Length > 0)
        {
            foreach(var target in targets)
            {
                IDamageable monster = target.GetComponent<IDamageable>();
                monster?.GetDamage(damage);
                Invoke("ExplosionPhysics", 0.1f);
            }
        }

    }
    private void ExplosionPhysics()
    {
        Collider[] deadBodies = Physics.OverlapSphere(transform.position, range, 1 << 11);
        if (deadBodies.Length > 0)
        {
            foreach (var body in deadBodies)
            {
                Rigidbody monster = body.GetComponent<Rigidbody>();
                monster?.AddExplosionForce(explosionPower, transform.position, range);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(transform.position, range);
    }
}
