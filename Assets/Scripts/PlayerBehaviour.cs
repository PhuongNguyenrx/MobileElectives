using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for player things.
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] List<Transform> projectiles;
    [SerializeField] float health = 100;
    [SerializeField] float speed = 5;
    List<ShootController> shootControllers = new();
    MovementController movementController;

    void Start()
    {
        Input.multiTouchEnabled = false;
        movementController = new MovementController(transform,speed);
        foreach (var t in projectiles)
        {
            shootControllers.Add(new ShootController(t.GetComponent<Projectile>(),transform));
        }
    }

    void Update()
    {
        movementController.HandleMovementInput();
        foreach(var shootController in shootControllers)
        {
            shootController.ShootCountdown();
        }
    }
    
    public void IncreaseDamage(float damageToIncrease)
    {
        foreach(var shootController in shootControllers)
        {
            shootController.IncreaseDamage(damageToIncrease);
        }
    }

    public void IncreaseSpeed(float speedToIncrease)
    {
        foreach (var shootController in shootControllers)
        {
            shootController.IncreaseSpeed(speedToIncrease);
        }
    }
    public void ReduceReload(float reloadTime)
    {
        foreach (var shootController in shootControllers)
        {
            shootController.ReduceReload(reloadTime);
        }
    }
    public void IncreaseHealth(float healthToIncrease) => health += healthToIncrease;
}
