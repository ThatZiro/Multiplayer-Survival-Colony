using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
Animator animator;
int isWalkingHash;
int isRunningHash;
int isWalkingBackwardsHash;
int isRunningBackwardsHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        isRunningBackwardsHash = Animator.StringToHash("isRunningBackwards");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool backwardPressed = Input.GetKey("s");        
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isrunning = animator.GetBool(isRunningHash);
        bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
        bool isRunningBackwards = animator.GetBool(isRunningBackwardsHash);
        
        


        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isrunning && (runPressed && forwardPressed))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isrunning && (!runPressed || !forwardPressed))
        {
            animator.SetBool(isRunningHash, false);
        }
                if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (!isWalkingBackwards && backwardPressed)
        {
            animator.SetBool(isWalkingBackwardsHash, true);
        }

        if (isWalkingBackwards && !backwardPressed)
        {
            animator.SetBool(isWalkingBackwardsHash, false);
        }

        if (!isRunningBackwards && (runPressed && backwardPressed))
        {
            animator.SetBool(isRunningBackwardsHash, true);
        }

        if (isRunningBackwards && (!runPressed || !backwardPressed))
        {
            animator.SetBool(isRunningBackwardsHash, false);
        }
    }
}
