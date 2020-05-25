using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float flySpeedNormal;

    public float flySpeedSlow;

    Vector2 moveInput;

    private void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput = Vector2.ClampMagnitude(moveInput, Mathf.Sqrt(2f));
        
        moveInput *= Time.deltaTime * flySpeedNormal;

        transform.position += new Vector3(moveInput.x, moveInput.y, transform.position.z);
    }
}
