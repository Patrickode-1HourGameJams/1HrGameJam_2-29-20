using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Collider coll;

    public float maxVelocity = 5;
    public float accelSpeed = 1;

    void Update()
    {
        //Set up a movement vector.
        Vector3 moveDir = Vector3.zero;

        //If the WASD keys are held, add the corresponding direction to the move direction.
        if (Input.GetKey(KeyCode.W))
        {
            moveDir += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir += Vector3.right;
        }

        //Now apply that move direction to actual movement.
        if (moveDir != Vector3.zero)
        {
            ApplyMoveInput(moveDir);
        }
    }

    /// <summary>
    /// Applies velocity in the given direction.
    /// </summary>
    /// <param name="forceDir">The direction to move in.</param>
    private void ApplyMoveInput(Vector3 forceDir)
    {
        //Get the velocity without a y component, make a clamped speed vector, and apply it to velocity.
        //This effectively ignores the y axis of velocity, allowing normal gravity things to happen.
        Vector3 velSubY = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 newVel = Vector3.ClampMagnitude(velSubY + forceDir * accelSpeed, maxVelocity);
        rb.velocity = new Vector3(newVel.x, rb.velocity.y, newVel.z);
    }
}
