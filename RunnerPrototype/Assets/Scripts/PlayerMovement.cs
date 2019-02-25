using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    public bool runAutomatically = true;
    public float speed = 6.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        controller = GetComponent<CharacterController>();

        // let the gameObject fall down
        //gameObject.transform.position = new Vector3(0, 5, 0);
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal") * -1, 0.0f, runAutomatically ? 1 : Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection * speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

        // Move the controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}