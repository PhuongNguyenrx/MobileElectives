using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
            shootCooldown = cooldownCount - projectile.powerup.reloadBoost;
            Shoot();
        }
    }

    public void IncreaseDamage(float damageToIncrease)=>projectile.powerup.damageBoost += damageToIncrease;
    public void IncreaseSpeed(float speedToIncrease)=>projectile.powerup.speedBoost += speedToIncrease;

    public void ReduceReload(float reloadTime) => projectile.powerup.reloadBoost += reloadTime;
    void Shoot()
    {
        var instantiatedProjectile = GameObject.Instantiate(projectile, ownerObject.position, Quaternion.identity);
    }
}
