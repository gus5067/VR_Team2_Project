using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTraceBehaviour : StateMachineBehaviour
{
    private ViewDetector viewDetector;
    private NavMeshAgent agent;
    private Zombie zombie;
    private CharacterController controller;
    private float speed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        viewDetector = animator.GetComponent<ViewDetector>();
        agent = animator.GetComponent<NavMeshAgent>();
        zombie = animator.GetComponent<Zombie>();

        speed = zombie.Speed;
        controller = zombie.characterController;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (viewDetector.FindTarget() && agent.enabled == true)
        {
            agent.SetDestination(viewDetector.target.transform.position);
        }
        else if(viewDetector.FindTarget() == false)
        {
            ObjectPooling.poolDic["Zombie"].ReturnPool(animator.gameObject);
            return;
        }
        else if (agent.enabled == false)
        {
            Vector3 moveDir = (viewDetector.target.transform.position - animator.transform.position).normalized * speed;
            if (controller.isGrounded == false)
            {
                controller.Move(new Vector3(moveDir.x, Physics.gravity.y, moveDir.z) * Time.deltaTime);
            }
            else
            {
                controller.Move(moveDir * Time.deltaTime);
            }

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
