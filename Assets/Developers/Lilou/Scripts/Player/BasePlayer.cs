using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayer : MonoBehaviour
{
    // properties

    // references
    [SerializeField] public Camera PlayerCamera;
    [SerializeField] public Rigidbody2D RigidBody;

    // // movement
    [SerializeField] public float WalkSpeedMax = 10.0f;
    [SerializeField] public float WalkAcceleration = 500.0f;
    [SerializeField] public float WalkFriction = 1.25f;

    // // input
    private Vector2 MovementInput;
    private Vector2 RotationInput;

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
        UpdateRotation();
    }

    // // update input
    void UpdateInput()
    {
        // update movement input
        MovementInput = new Vector2(-Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        // update rotation input
        RotationInput = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);
        // RotationInput = Input.mousePosition;
    }

    // // update movement
    void UpdateMovement()
    {
        if (MovementInput == Vector2.zero)
        {
            ApplyFriction(WalkFriction);
        }
        else
        {
            ApplyMovement(MovementInput, WalkAcceleration);
        }
    }

    // // apply movement
    void ApplyMovement(Vector2 Direction, float Amount, float Delta = 1)
    {
        RigidBody.MovePosition(RigidBody.position + Vector2.ClampMagnitude(RigidBody.velocity + Direction * Amount, WalkSpeedMax) * Time.fixedDeltaTime);
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

    // // update rotation
    void UpdateRotation()
    {
        Vector2 LookVector = RotationInput - RigidBody.position;
        RigidBody.rotation = Mathf.Atan2(LookVector.y, LookVector.x) * Mathf.Rad2Deg - 90f;
    }
}
