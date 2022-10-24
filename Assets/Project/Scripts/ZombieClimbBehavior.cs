using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieClimbBehavior : StateMachineBehaviour
{
    private NavMeshAgent agent;
    private Zombie zombie;
    private CharacterController controller;
    private float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        zombie = animator.GetComponent<Zombie>();

        controller = zombie.characterController;

        speed = zombie.Speed;
        agent.enabled = false;
        controller.enabled = true;
        GameManager.instance.busController.Speed -= zombie.SlowSpeed;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       

        if(animator.transform.localPosition.y < 1.2f)
        {
            animator.transform.localPosition += Vector3.up * 0.5f * Time.deltaTime;
        }
        else
        {
            Mathf.Clamp(animator.transform.localPosition.y, 0f, 1.2f);
            zombie.isHanging = true;
        }

        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameManager.instance.busController.Speed += zombie.SlowSpeed;
        zombie.isHanging = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
