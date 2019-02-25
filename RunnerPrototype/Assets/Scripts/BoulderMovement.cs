using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMovement : MonoBehaviour
{
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    public Vector3 moveDirection = Vector3.zero;
    public float speed = 6.0f;
    private CharacterController controller;
    private Rigidbody rb;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(0f, 0.0f, 1);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }

    //private void Update()
    //{
    //    // We are grounded, so recalculate
    //    // move direction directly from axes

    //    moveDirection = new Vector3(0f, 0.0f, 1);
    //    moveDirection = transform.TransformDirection(moveDirection);
    //    moveDirection = moveDirection * speed;

    //    // Apply gravity
    //    moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

    //    // Move the controller
    //    //rb.Move(moveDirection * Time.deltaTime);
    //    rb.AddForce(moveDirection);
    //}
}