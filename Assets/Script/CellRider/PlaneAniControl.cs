using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAniControl : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    Vector2 input;

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        if(input.y>0)
        {
            animator.SetTrigger("FlyUp");
        }
        else if(input.y<0)
        {
            animator.SetTrigger("FlyDown");
        }   
        else if(input.x<0)
        {
            animator.SetTrigger("FlyLeft");
        }
        else if(input.x>0)
        {
            animator.SetTrigger("FlyRight");
        }
        else
        {
            animator.SetTrigger("Fly");
        }
    }
}
