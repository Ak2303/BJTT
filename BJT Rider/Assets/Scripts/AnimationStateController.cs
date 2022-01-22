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
        bool wPressed = Input.GetKey("up");
        bool aPressed = Input.GetKey("left");
        bool dPressed = Input.GetKey("right");
        bool isRunning = animator.GetBool("isRunning");
        bool isLeft = animator.GetBool("isLeft");
        bool isRight = animator.GetBool("isRight");


        if(!isRunning && wPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if(isRunning && !wPressed){
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
