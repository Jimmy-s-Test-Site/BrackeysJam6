using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBulletBehaviour : ScriptableObject
{
    // properties

    [SerializeField] public GameObject HitEffect;
    [SerializeField] public float EffectDuration = 5.0f;
    [SerializeField] public float BulletDuration = 0.0f;

    // methods

    // // fire start
    public abstract void FireStart(BaseWeapon InCaller, Transform InTransform);

    // // fire stop
    public abstract void FireStop();
}
