using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
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
    private Vector2 InputAxis;

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
        // update input axis
        InputAxis = GetInputAxis();
    }

    // // update movement
    void UpdateMovement()
    {
        if (InputAxis == Vector2.zero)
        {
            ApplyFriction(WalkFriction);
        }
        else
        {
            ApplyMovement(InputAxis, WalkAcceleration);
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

    void UpdateRotation()
    {
        Vector3 Distance = Input.mousePosition - PlayerCamera.WorldToScreenPoint(transform.position); ;
        Vector3 MousePos = new Vector3(Distance.x, Distance.y);

        transform.rotation = Quaternion.Inverse(Quaternion.LookRotation(Vector3.forward, MousePos));
    }
}
