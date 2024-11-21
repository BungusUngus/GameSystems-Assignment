using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : RayCastFromScreenCentre
{
    private DamageSource damageSource;
    private GunEffect effect;

    protected override void Start()
    {
        //base. refers to the parent script
        //base.start() will run the parent's start() on this script
        base.Start();
        damageSource = GetComponent<DamageSource>();
        effect = GetComponentInChildren<GunEffect>();
    }

    public void Shoot()
    {
        //TryToHit() comes from our parent script (RaycastFromScreenCentre)
        //if we hit something, hit.collider will have a value. Else, hit.collider will be null
        RaycastHit hit = TryToHit();

        //if we did hit something...
        if (hit.collider)
        {
            //if the thing we hit has a damageable component...
            if (hit.rigidbody && hit.rigidbody.TryGetComponent<Damageable>(out Damageable agent))
            {
                agent.TakeDamage(damageSource.GetDamage());
            }
        }

        effect.Play(hit.point);
    }
}
