using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for moving the player automatically and receiving input.
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    List<Transform> projectiles;
    List<ShootController> shootControllers = new();
    MovementController movementController;

    void Start()
    {
        Input.multiTouchEnabled = false;
        movementController = new MovementController(transform);
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
    
}
