using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        bool wPressed = Input.GetKey("w");
        bool aPressed = Input.GetKey("a");
        bool dPressed = Input.GetKey("d");
        bool shiftPressed = Input.GetKey("left shift");
        bool spacePressed = Input.GetKey(KeyCode.Space);
        bool isRunning = animator.GetBool("isRunning");
        bool isLeft = animator.GetBool("isLeft");
        bool isRight = animator.GetBool("isRight");
        bool isWalking = animator.GetBool("isWalking");
        bool isJumping = animator.GetBool("isJumping");

        if(spacePressed){
            animator.SetBool("isJumping", true);
        }
        if(!spacePressed){
            animator.SetBool("isJumping", false);
        }
        if(!isWalking && wPressed)
        {
            animator.SetBool("isWalking", true);
        }
        if(isWalking && !wPressed){
            animator.SetBool("isWalking", false);
        }

        if(!isRunning && shiftPressed)//ig
        {
            animator.SetBool("isRunning", true);
        }
        if(isRunning && !shiftPressed){
            animator.SetBool("isRunning", false);
        }

        if(aPressed)
        {
            animator.SetBool("isLeft", true);
        }
        if(!aPressed){
            animator.SetBool("isLeft", false);
        }

        if(dPressed)
        {
            animator.SetBool("isRight", true);
        }
        if(!dPressed){
            animator.SetBool("isRight", false);
        }
    }
}
