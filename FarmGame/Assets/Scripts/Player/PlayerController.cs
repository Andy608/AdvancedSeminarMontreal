using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private Vector3 lookDirection = new Vector2();
    private Vector3 mouseWorldPosition = new Vector3();

    private Rigidbody2D playerRigidbody;

    public float moveSpeed = 10.0f;
    public float movementSmoothing = 0.05f;

    private Vector2 moveVelocity = new Vector2();
    private Vector3 currentVelocity = Vector3.zero;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateLookDirection();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        moveVelocity.x = Input.GetAxisRaw(HORIZONTAL);
        moveVelocity.y = Input.GetAxisRaw(VERTICAL);
        moveVelocity.Normalize();

        moveVelocity *= moveSpeed * Time.fixedDeltaTime;

        Vector3 targetVelocity = new Vector2(moveVelocity.x, moveVelocity.y);

        playerRigidbody.velocity = Vector3.SmoothDamp(playerRigidbody.velocity, targetVelocity, ref currentVelocity, movementSmoothing);
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
}
