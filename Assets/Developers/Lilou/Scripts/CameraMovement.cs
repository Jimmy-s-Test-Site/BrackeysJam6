using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // properties

    public Transform Target;
    [Range(0.01f, 1)] public float Smoothing;

    // methods

    // // on physics update
    void FixedUpdate()
    {
        Vector3 NewPosition = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, NewPosition, Smoothing);
    }
}
