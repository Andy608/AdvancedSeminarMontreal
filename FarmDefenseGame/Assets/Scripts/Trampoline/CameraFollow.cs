using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        Vector3 moveTowards = Vector2.MoveTowards(transform.position, target.transform.position, 5.0f);
        moveTowards.z = transform.position.z;
        transform.position = moveTowards;
    }
}
