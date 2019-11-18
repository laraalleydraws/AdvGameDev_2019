using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : StateMachineBehaviour {


    private Transform playerPos;
    public float speed;

    // Start
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {


        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
	}

    // Update
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetBool("isFollowing", false);
        }

        if (Input.GetKeyDown(KeyCode.P)) {
            animator.SetBool("isPatrolling", true);
        }
	}

    //Stops
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}


}
