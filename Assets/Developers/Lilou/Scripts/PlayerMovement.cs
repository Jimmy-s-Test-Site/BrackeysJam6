using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // properties

    // // physics
    public Rigidbody2D RigidBody;
    
    // // input
    private Vector2 InputAxis;

    // // movement
    public float MaxSpeed;
    public float Acceleration;
    public float Friction;

    // methods

    // // on start
    void Start()
    {

    }

    // // on frame update
    void Update()
    {
        UpdateInput();
    }

    // // on physics update
    private void FixedUpdate()
    {
        UpdateMovement();
    }

    // // update input
    void UpdateInput()
    {
        // update input axis
        InputAxis = GetInputAxis();
    }

    // // update movement
    void UpdateMovement()
    {
        if (InputAxis == Vector2.zero)
        {
            ApplyFriction(Friction);
        }
        else
        {
            ApplyMovement(InputAxis, Acceleration);
        }
    }

    // // get input axis
    Vector2 GetInputAxis()
    {
        return new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    // // apply movement
    void ApplyMovement(Vector2 Direction, float Amount, float Delta = 1)
    {
        RigidBody.MovePosition(RigidBody.position + Vector2.ClampMagnitude(RigidBody.velocity + Direction * Amount, MaxSpeed) * Time.fixedDeltaTime);
    }

    // // apply friction
    void ApplyFriction(float Amount)
    {
        if (RigidBody.velocity.magnitude > Amount)
        {
            RigidBody.velocity -= RigidBody.velocity.normalized * Amount;
        }
        else
        {
            RigidBody.velocity = Vector2.zero;
        }
    }
}
