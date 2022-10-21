using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour,IDamageable
{
    [SerializeField]
    private float hp;
    public float Hp
    {
        get { return hp; }
        set
        {
            if (value <= 0)
            {
                Die();
            }
            else
            {
                hp = value;
            }

        }
    }
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }

    [SerializeField, Range(0f, 10f)]
    private float attackRange;
    public float AttackRange { get { return attackRange; } }

    [SerializeField, Range(0f, 5f)]
    private float speed;
    public float Speed { get { return speed; } }

    [SerializeField, Range(0f, 2f)]
    private float slowSpeed;
    public float SlowSpeed { get { return slowSpeed; } }

    [SerializeField, Range(0f, 5f)]
    private float attackTime;
    public float AttackTime { get { return attackTime; } }

    private bool isCoolTime;

    private Animator animator;
    [SerializeField]
    private GameObject ragDoll;

    [SerializeField]
    public CharacterController characterController;

    private NavMeshAgent agent;

    public bool isHanging;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        agent.speed = this.Speed;
    }
    private void Update()
    {
        FindWall();
        Attack();
    }

    private void FindWall()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.6f, transform.forward);
        Debug.DrawRay(transform.position + Vector3.up * 0.7f, transform.forward * 0.7f, Color.red);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 0.7f, 1 << 8))
        {
            animator.SetBool("isRun", false);
            this.transform.SetParent(hit.transform.parent);
            animator.SetBool("isClimb", true);
            //if(hit.collider.tag == "RightWall")
            //{
            //    //transform.localRotation = Quaternion.Euler(0, -90, 0);
            //}
            //else if (hit.collider.tag == "LeftWall")
            //{
            //    transform.localRotation = Quaternion.Euler(0, 90, 0);
            //}
        }
        else
        {
            animator.SetBool("isClimb", false);
            return;
        }
    }

    private void Attack()
    {
        if (isHanging && !isCoolTime)
        {
            StartCoroutine("AttackRoutine", AttackTime);
        }
        else
        {
            return;
        }
    }

    private IEnumerator AttackRoutine(float time)
    {
        isCoolTime = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(time);
        isCoolTime = false;

    }
    //private void InAttackRange()
    //{
    //    Collider[] targets = Physics.OverlapSphere(transform.position, attackRange, 1 << 6);
    //    if(targets.Length > 0)
    //    {
    //        animator.SetBool("isRun", false);
    //        animator.SetTrigger("Attack");
    //    }
    //    else
    //    {
    //        return;
    //    }
    //}

    public void GetDamage(float damage)
    {
        animator.SetTrigger("Hit");
        Hp -= damage;
    }

    private void Die()
    {
        ObjectPooling.poolDic["Zombie_Ragdoll"].GetPool(transform.position, transform.rotation);
        ObjectPooling.poolDic["Zombie"].ReturnPool(this.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, attackRange);
    }
}
