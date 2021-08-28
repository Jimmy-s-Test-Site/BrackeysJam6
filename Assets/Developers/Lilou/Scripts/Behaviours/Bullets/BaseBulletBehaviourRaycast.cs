using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBehaviourRaycast", menuName = "Bullet Behaviours/Raycast")]
public class BaseBulletBehaviourRaycast : BaseBulletBehaviour
{
    // properties


    // methods

    // // on start
    void Start()
    {
        
    }

    // // fire start
    public override void FireStart(BaseWeapon InCaller, Transform InTransform)
    {
        float MaxDistance = 1000.0f;
        RaycastHit HitResult;

        if (Physics.Raycast(InTransform.position, InTransform.forward, out HitResult, MaxDistance))
        {
            Debug.Log(HitResult.transform.name);
        }
    }

    // // fire stop
    public override void FireStop()
    {

    }
}
