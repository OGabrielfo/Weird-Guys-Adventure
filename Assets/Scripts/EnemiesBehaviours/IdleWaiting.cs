using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWaiting : StateMachineBehaviour
{

    private Patroller _patrol;
    private PatrollerSkull _patrolSkull;
    private Rigidbody2D _rb;
    private float _waitTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.GetComponent<Patroller>() != null)
        {
            _patrol = animator.GetComponent<Patroller>();
            _waitTime = _patrol.waitTime;
        }
        else if (animator.GetComponent<PatrollerSkull>() != null)
        {
            _patrolSkull = animator.GetComponent<PatrollerSkull>();
            _waitTime = _patrolSkull.waitTime;
        }
        _rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_waitTime > 0)
        {
            _rb.velocity = new Vector2(0f, _rb.velocity.y);
            _waitTime -= Time.deltaTime;
        } else
        {
            animator.SetBool("Idle", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _rb.velocity = Vector3.zero;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
