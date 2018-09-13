using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private Vector2 velocity = new Vector2();
    private Vector3 lookDirection = new Vector2();

    private Vector3 mouseWorldPosition = new Vector3();

    public float moveSpeed = 10.0f;

    public float minimumMouseDistance = 0f;

    private void Update()
    {
        UpdateLookDirection();

        if (!IsMouseTooClose())
        {
            RotatePlayer();
        }

        MovePlayer();
    }

    private void MovePlayer()
    {
        velocity.x = Input.GetAxis(HORIZONTAL) * Time.deltaTime * moveSpeed;
        velocity.y = Input.GetAxis(VERTICAL) * Time.deltaTime * moveSpeed;

        transform.Translate(velocity);
    }

    private void RotatePlayer()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90.0f));
    }

    private void UpdateLookDirection()
    {
        mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        lookDirection = mouseWorldPosition - transform.position;
    }

    private bool IsMouseTooClose()
    {
        return lookDirection.sqrMagnitude <= minimumMouseDistance;
    }
}
