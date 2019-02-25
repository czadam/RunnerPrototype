using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignWithGround : MonoBehaviour
{
    public float rayLength = 5f;
    public float speed;

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, rayLength))
        {
            if (hit.transform.gameObject.CompareTag("Ground"))
            {
                Debug.Log("Adjust rotation");
                var toRotation = Quaternion.LookRotation(hit.transform.up);
                //TODO: use different speed component
                transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
            }
        }
    }
}