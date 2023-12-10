using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController
{
    Projectile projectile;
    Transform ownerObject;
    float shootCooldown;
    float cooldownCount;
    public ShootController(Projectile projectile, Transform ownerObject)
    {
        this.projectile = projectile;
        this.ownerObject = ownerObject;
        cooldownCount = projectile.cooldownCount;
        shootCooldown = cooldownCount;
    }
    public void ShootCountdown()
    {
        if (shootCooldown > 0)
            shootCooldown -= Time.deltaTime;
        else
        {
            shootCooldown = cooldownCount;
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject.Instantiate(projectile, ownerObject.position, Quaternion.identity);
    }
}
