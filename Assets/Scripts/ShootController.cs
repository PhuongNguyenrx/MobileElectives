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
            shootCooldown = cooldownCount;
            Shoot();
        }
    }

    public void IncreaseDamage(float damageToIncrease) => projectile.bulletDamage += damageToIncrease; //TODO: dont change original prefab

    public void IncreaseSpeed(float speedToIncrease) => projectile.bulletSpeed += speedToIncrease;

    public void ReduceReload(float reloadTime) => projectile.cooldownCount += reloadTime;
    void Shoot()
    {
        GameObject.Instantiate(projectile, ownerObject.position, Quaternion.identity);
    }
}
