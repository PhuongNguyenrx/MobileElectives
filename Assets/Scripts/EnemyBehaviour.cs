using UnityEngine;
using System;

public class EnemyBehaviour : Damageable
{
    [SerializeField] float directionChangeInterval;
    Vector3 movementDirection;
    private void Start()
    {
        CalculateDirection();
    }
    private void FixedUpdate()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y <= 0)
            Destroy(gameObject);
        if (Time.time % directionChangeInterval == 0 || (screenPosition.y >= Screen.height) || (screenPosition.x >= Screen.width) || (screenPosition.x <= 0f))
            CalculateDirection();
        Move(movementDirection);
    }

    private void CalculateDirection()
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        var dirX = screenPosition.x >= Screen.width ? -1 : screenPosition.x <= 0 ? 1 : UnityEngine.Random.Range(-1.0f, 1.0f);
        var dirY = screenPosition.y >= Screen.height ? -1 : UnityEngine.Random.Range(-1.0f, 1.0f);
        movementDirection = new Vector3(dirX, dirY, 0);
    }

}
