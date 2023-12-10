using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for moving the player automatically and receiving input.
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    List<Projectile> projectiles;
    MovementController movementController;
    public List<ShootController> shootControllers = new();

    void Start()
    {
        Input.multiTouchEnabled = false;
        movementController = new MovementController(transform);
        foreach (var t in projectiles)
        {
            shootControllers.Add(new ShootController(t,transform));
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
    
}
