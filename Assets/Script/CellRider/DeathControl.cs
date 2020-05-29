using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathControl : MonoBehaviour
{
    public Animator animator;
    private bool isDie;
    private void Start()
    {
        isDie = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("PlayerBullet"))
        {
            animator.SetTrigger("Explore");
            isDie = true;
        }
    }

    private void Update()
    {
        //if (isDie && animator.GetCurrentAnimatorStateInfo(0).IsName("death_explore"))
        //{
        //    gameObject.SetActive(false);
        //}
    }
}
