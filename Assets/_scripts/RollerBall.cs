using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollerBall : MonoBehaviour
{
    public float speed;

    public Rigidbody rb;

    private float movementX, movementY;
    private bool isActive;

    private Vector3 currentAngularV, currentV;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isActive = true;
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void OnPause()
    {
        toggleActive(!isActive);
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            Vector3 movement = new Vector3(movementX, 0, movementY);

            rb.AddForce(movement * speed);

            currentV = rb.velocity;
            currentAngularV = rb.angularVelocity;
        }
        else
        {
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }

    public void toggleActive(bool b)
    {
        isActive = b;
        rb.angularVelocity = currentAngularV;
        rb.velocity = currentV;
    }

}