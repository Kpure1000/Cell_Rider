using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MyCollider))]
public class PlayerController : MonoBehaviour
{
    private Vector2 velocity;

    private MyCollider myCollider;

    public float Speed = 0f;

    public Rect Range;

    private void Start()
    {
        myCollider = GetComponent<MyCollider>();
    }

    private void Update()
    {
        //Move Controller
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    private void FixedUpdate()
    {
        myCollider.MoveAs(velocity * Time.deltaTime * Speed);

        if (myCollider.rigidbody2D.position.x < Range.x)
        {
            myCollider.rigidbody2D.position = new Vector2(Range.x, myCollider.rigidbody2D.position.y);
        }
        if (myCollider.rigidbody2D.position.x > Range.x + Range.width)
        {
            myCollider.rigidbody2D.position = new Vector2(Range.x + Range.width, myCollider.rigidbody2D.position.y);
        }
        if (myCollider.rigidbody2D.position.y < Range.y)
        {
            myCollider.rigidbody2D.position = new Vector2(myCollider.rigidbody2D.position.x, Range.y);
        }
        if (myCollider.rigidbody2D.position.y > Range.y + Range.height)
        {
            myCollider.rigidbody2D.position = new Vector2(myCollider.rigidbody2D.position.x, Range.y + Range.height);
        }

    }
}
