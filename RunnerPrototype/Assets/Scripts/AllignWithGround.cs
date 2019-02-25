using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignWithGround : MonoBehaviour
{
    public float rayLength = 5f;
    public float speed;

    private Vector3 dir = Vector3.forward;

    // Update is called once per frame
    //private void Update()
    //{
    //    RaycastHit hit;
    //    // Does the ray intersect any objects excluding the player layer
    //    if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, rayLength))
    //    {
    //        if (hit.transform.gameObject.CompareTag("Ground"))
    //        {
    //            Debug.Log("Adjust rotation");
    //            var toRotation = Quaternion.LookRotation(hit.transform.up);
    //            //TODO: use different speed component
    //            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
    //        }
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            dir = other.transform.up;
        }
    }

    private void Update()
    {
        var toRotation = Quaternion.LookRotation(dir);

        if (Quaternion.Angle(toRotation, transform.rotation) > 5f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
            Debug.Log("Adjust rotation");
        }
    }
}