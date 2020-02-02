using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public bool isHammering;
    public bool isIdle;
    public bool isRunning;

    Vector3 runDistance = new Vector3(0.1f, 0, 0);
    public float LeftBound = -10;
    public float RightBound = 10;
    bool right = true;
    bool left;

    Animator animator;

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isHammering", isHammering);
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isRunning", isRunning);
    }

    private void FixedUpdate()
    {
        if (isRunning == true)
        {
            if(transform.position.x > RightBound)
            {
                left = true;
                right = false;
                transform.localScale = new Vector3(-1, 1, 1);
            }

            else if(transform.position.x < LeftBound)
            {
                left = false;
                right = true;
                transform.localScale = new Vector3(1, 1, 1);
            }

            if(left == true)
            {
                transform.Translate(-runDistance);
            }

            else if(right == true)
            {
                transform.Translate(runDistance);
            }
            
        }
    }

}
