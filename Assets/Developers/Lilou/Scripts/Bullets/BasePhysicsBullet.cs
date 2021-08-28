using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePhysicsBullet : MonoBehaviour
{
    // properties

    [SerializeField] public GameObject HitEffect;
    [SerializeField] public float EffectDuration;
    [SerializeField] public float BulletDuration;

    // methods

    // constructor
    BasePhysicsBullet(GameObject InHitEffect, float InEffectDuration, float InBulletDuration)
    {
        HitEffect = InHitEffect;
        EffectDuration = InEffectDuration;
        BulletDuration = InBulletDuration;
    }

    // // on collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (HitEffect)
        {
            GameObject Effect = Instantiate(HitEffect, transform);
            Destroy(Effect, EffectDuration);
        }

        Destroy(gameObject, BulletDuration);
    }
}
