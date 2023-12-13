using UnityEngine;
using System;

public class MovingEnemy : Lootable
{
    [SerializeField] float directionChangeInterval;
    [SerializeField] float moveSpeed;
    Vector3 movementDirection;
    MovementController movementController;
    private void Start()
    {
        movementController = new MovementController(transform);
        CalculateDirection();
    }
    private void FixedUpdate()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y <= 0)
            Destroy(gameObject);
        if (Time.time % directionChangeInterval == 0 || (screenPosition.y >= Screen.height) || (screenPosition.x >= Screen.width) || (screenPosition.x <= 0f))
            CalculateDirection();
        movementController.DirectionalMove(movementDirection, moveSpeed);
    }

    private void CalculateDirection()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        var dirX = screenPosition.x >= Screen.width ? -1 : screenPosition.x <= 0 ? 1 : UnityEngine.Random.Range(-1.0f, 1.0f);
        var dirY = screenPosition.y >= Screen.height ? -1 : UnityEngine.Random.Range(-1.0f, 1.0f);
        movementDirection = new Vector3(dirX, dirY, 0);
    }

}
