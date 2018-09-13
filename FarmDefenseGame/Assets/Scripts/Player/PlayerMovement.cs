using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum MovementType
    {
        RUN     = 20,
        WALK    = 10,
        SNEAK   = 5
    }

    private const string X_AXIS_ID = "Horizontal";
    private const string Y_AXIS_ID = "Vertical";

    public MovementType playerMovementType = MovementType.WALK;

    private float moveSpeed;

    private void Start()
    {
        UpdateMoveSpeed();
    }

    private void OnValidate()
    {
        UpdateMoveSpeed();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 velocity;
        velocity.x = Input.GetAxis(X_AXIS_ID) * Time.deltaTime * moveSpeed;
        velocity.y = Input.GetAxis(Y_AXIS_ID) * Time.deltaTime * moveSpeed;

        transform.Translate(velocity.x, velocity.y, 0);
    }

    private void UpdateMoveSpeed()
    {
        moveSpeed = (int)playerMovementType;
    }
}
