using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllignWithGround : MonoBehaviour
{
    public float speed;

    private Vector3 dir = Vector3.forward;

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

        if (Quaternion.Angle(toRotation, transform.rotation) > 1f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, speed * Time.deltaTime);
            Debug.Log("Adjust rotation");
        }
    }
}