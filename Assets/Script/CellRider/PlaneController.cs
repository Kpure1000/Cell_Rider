using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float flySpeedNormal;

    public float flySpeedSlow;

    Vector2 moveInput;

    Rigidbody2D rb2d;

    MyCollider myCollider;

    PlayerTimeBack timeBack;

    private void Start()
    {
        timeBack = GetComponent<PlayerTimeBack>();
        rb2d = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<MyCollider>();
    }

    private void Update()
    {
        if (!timeBack.isBacking)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput = Vector2.ClampMagnitude(moveInput, Mathf.Sqrt(2f));

            moveInput *= Time.deltaTime * flySpeedNormal;

            transform.position += new Vector3(moveInput.x, moveInput.y, 0);
        }
    }

}
