using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBehaviourPhysics", menuName = "Bullet Behaviours/Physics")]
public class BaseBulletBehaviourPhysics : BaseBulletBehaviour
{
    // properties

    [SerializeField] GameObject BulletPrefab;

    // methods

    // // on start
    void Start()
    {
        
    }

    // // fire start
    public override void FireStart(BaseWeapon InCaller, Transform InTransform)
    {
        GameObject Bullet = Instantiate(BulletPrefab, InTransform);
        Rigidbody2D BulletRigidBody = Bullet.GetComponent<Rigidbody2D>();
        BulletRigidBody.AddForce(InTransform.up * InCaller.BulletSpeed, ForceMode2D.Impulse);
    }

    // // fire stop
    public override void FireStop()
    {

    }
}
