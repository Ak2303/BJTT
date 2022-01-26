using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleAnimatorController : MonoBehaviour
{

    Animator animator;
    float velocityZ = 0.0f;
    float velocityX = 0.0f;
    public float acceleration = 2.0f;
    public float deceleration = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPress = Input.GetKey("w");
        bool leftPress = Input.GetKey("a");
        bool rightPress = Input.GetKey("d");
        bool runPress = Input.GetKey("left shift");

        if(forwardPress){
            velocityZ += Time.deltaTime + acceleration; 
        }


        if(leftPress){
            velocityX -= Time.deltaTime + acceleration;
        }

        if(rightPress){
            velocityX += Time.deltaTime + acceleration;
        }

        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
