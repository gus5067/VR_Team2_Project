using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Debug.Log("���� ü�� : " + hp);
            }

        }
    }
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }

    [SerializeField, Range(0f, 10f)]
    private float attackRange;
    public float AttackRange { get { return attackRange; } }

    private Animator animator;
    [SerializeField]
    private GameObject ragDoll;

    [SerializeField]
    public CharacterController characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        FindWall();
        InAttackRange();
    }

    private void FindWall()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.6f, transform.forward);
        Debug.DrawRay(transform.position + Vector3.up * 0.7f, transform.forward * 0.7f, Color.red);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 0.7f, 1 << 8))
        {
            Debug.Log("�浹��");
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

    private void InAttackRange()
    {
        Collider[] targets = Physics.OverlapSphere(transform.position, attackRange, 1 << 6);
        if(targets.Length > 0)
        {
            Debug.Log("���ݹ���");
            animator.SetBool("isRun", false);
            animator.SetTrigger("Attack");
        }
        else
        {
            return;
        }
    }

    public void GetDamage(float damage)
    {
        Hp -= damage;
    }

    private void Die()
    {
        Instantiate(ragDoll, transform.position, transform.rotation);
        gameObject.SetActive(false); //���߿� ������Ʈ Ǯ��
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + Vector3.up, attackRange);
    }
}
