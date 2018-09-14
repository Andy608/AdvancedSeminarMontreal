using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject targetObject;

    //The offset from where the camera is to the target.
    public Vector3 offset = new Vector3();

    public void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, targetObject.transform.position + offset, 2.0f * Time.fixedDeltaTime);
    }
}
