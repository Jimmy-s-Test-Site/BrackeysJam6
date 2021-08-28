using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    // properties

    [SerializeField] public Transform FirePoint;
    [SerializeField] public BaseBulletBehaviour BulletBehaviour;

    [SerializeField] public int FireRate = 600;
    [SerializeField] public int BulletSpeed = 20;
    [SerializeField] public int BulletDamage = 100;
    [SerializeField] public bool Automatic = true;

    private float NextFire = 0.0f;
    private bool CanFire = true;

    // methods

    // // on start
    void Start()
    {

    }

    // // on frame update
    void Update()
    {
        if (CanFire) FireInput();
        else
        {
            if (Input.GetMouseButtonDown(0)) FireStop();
            NextFire = 0.0f;
        }
    }

    // // fire input
    void FireInput()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0) && Time.time >= NextFire)
            {
                NextFire = Time.time + (60.0f / FireRate);
                FireStart();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                FireStop();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                FireStart();
                FireStop();
            }
        }
    }

    // // start firing
    private void FireStart()
    {
        if (BulletBehaviour) BulletBehaviour.FireStart(this, FirePoint);
    }

    // // stop firing
    private void FireStop()
    {
        if (BulletBehaviour) BulletBehaviour.FireStop();
    }
}
