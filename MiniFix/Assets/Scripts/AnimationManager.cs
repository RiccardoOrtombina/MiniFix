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
        float rng = Random.Range(0, 0.7f);
        Invoke("SetBools", rng);
    }

    void SetBools()
    {
        animator.SetBool("isHammering", isHammering);
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isRunning", isRunning);
    }

    private void FixedUpdate()
    {
        if (isRunning == true)
        {
            if(transform.localPosition.x > RightBound)
            {
                left = true;
                right = false;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.localPosition = new Vector3(RightBound - 1, transform.localPosition.y, transform.localPosition.z);
            }

            else if(transform.localPosition.x < LeftBound)
            {
                left = false;
                right = true;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                transform.localPosition = new Vector3(LeftBound + 1, transform.localPosition.y, transform.localPosition.z);              
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
