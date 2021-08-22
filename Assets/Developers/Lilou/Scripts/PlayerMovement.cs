using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // properties

    // // physics
    public Rigidbody2D RigidBody;

    // // movement
    public float MaxSpeed;
    public float MaxAcceleration;

    // // movement
    private Vector2 MovementDirection;

    // methods

    // // on start
    void Start()
    {

    }

    // // on frame update
    void Update()
    {
        ManageInput();
    }

    // // on physics update
    private void FixedUpdate()
    {
        AddMovementInput(MovementDirection, MaxSpeed);
    }

    // // manage input
    void ManageInput()
    {
        MovementDirection = new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    // // add movement input
    void AddMovementInput(Vector2 Direction, float Delta)
    {
        // apply input to rigid body
        RigidBody.velocity = new Vector2((Direction.x * Delta), (Direction.y * Delta));
    }
}
