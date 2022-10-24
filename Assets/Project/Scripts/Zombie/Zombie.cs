using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
public class Zombie : MonoBehaviour,IDamageable
{
    [SerializeField]
    protected float hp;
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
    protected float damage;
    public float Damage { get { return damage; } }

    [SerializeField, Range(0f, 10f)]
    protected float attackRange;
    public float AttackRange { get { return attackRange; } }

    [SerializeField, Range(0f, 5f)]
    protected float speed;
    public float Speed { get { return speed; } }

    [SerializeField, Range(0f, 2f)]
    protected float slowSpeed;
    public float SlowSpeed { get { return slowSpeed; } }

    [SerializeField, Range(0f, 5f)]
    protected float attackTime;
    public float AttackTime { get { return attackTime; } }

    protected bool isCoolTime;

    protected Animator animator;

    [SerializeField]
    protected GameObject ragDoll;

    [HideInInspector]
    public CharacterController characterController;

    [HideInInspector]
    public AudioSource zombieAudio;

    public AudioData audioData;

    protected NavMeshAgent agent;

    public bool isHanging;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        zombieAudio = GetComponent<AudioSource>();
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
        zombieAudio.clip = audioData.AudioClips[2];
        zombieAudio.Play();
        Hp -= damage;
    }

    protected virtual void Die()
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
