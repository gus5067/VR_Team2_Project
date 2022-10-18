using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    private Animator animator;
    [SerializeField]
    public CharacterController characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        FindWall();
    }

    private void FindWall()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 0.6f, transform.forward);
        Debug.DrawRay(transform.position + Vector3.up * 0.7f, transform.forward * 0.7f, Color.red);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, 0.7f, 1 << 8))
        {
            Debug.Log("Ãæµ¹ÇÔ");
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
}
