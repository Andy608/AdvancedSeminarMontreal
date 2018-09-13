using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject targetObject;

    //The offset from where the camera is to the target.
    public Vector3 offset = new Vector3();

    //How far away can the target before the camera starts to move towards it?
    //public float followDistance = 3.0f;
    //public float distanceTilStop = 1.0f;

    //bool followTarget = false;

    private void Start()
    {
        //Square it so we can use magnitude squared later on in the update method.
        //followDistance *= followDistance;
    }

    private void Update()
    {
        Vector2 targetPosition = targetObject.transform.position;
        Vector2 cameraPosition = transform.position;
        float distance = (targetPosition - cameraPosition).sqrMagnitude;

        //if (distance >= followDistance)
        //{
        //    followTarget = true;
        //}

        //if (distance <= distanceTilStop)
        //{
        //    followTarget = false;
        //}

        //if (followTarget)
        //{
            transform.position = Vector3.Lerp(transform.position, targetObject.transform.position + offset, 10.0f * Time.deltaTime);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetObject.transform.rotation, 10.0f * Time.deltaTime);
        //}
    }
}
