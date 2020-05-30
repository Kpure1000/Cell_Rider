using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeBack : MonoBehaviour
{
    public class PlayerTimeElement
    {
        public Vector3 position;

        public Sprite sprite;

        public PlayerTimeElement(Vector3 pos, Sprite spr)
        {
            position = pos;
            sprite = spr;
        }
    }

    TimeStack<PlayerTimeElement> timeStack;

    public bool isBacking;

    /**********************************************************/
    //外部依赖
    [Tooltip("依赖的Sprite所在Renderer")]
    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public int TimeBackLength;

    /**********************************************************/

    private void Start()
    {
        isBacking = false;
        timeStack = new TimeStack<PlayerTimeElement>(TimeBackLength);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isBacking = true;

            if (timeStack.isEmpty() == false)
            {
                transform.position = timeStack.Top().position;
                spriteRenderer.sprite = timeStack.Top().sprite;
                timeStack.Pop();
            }
        }
        else
        {
            isBacking = false;

            timeStack.Push(new PlayerTimeElement(transform.position, spriteRenderer.sprite));
        }

        if (isBacking)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }

    }
    
}
