using UnityEngine;
using System.Collections;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 20.0f;
    public float jumpSpeed = 8.0f;
    public bool runAutomatically = true;
    public float speed = 6.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.layer == LayerMask.NameToLayer("Boulder"))
        {
            GameManager.Instance().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.name);

        if (other.gameObject.layer == LayerMask.NameToLayer("FallCollider"))
        {
            GameManager.Instance().EndGame();
        }
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
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