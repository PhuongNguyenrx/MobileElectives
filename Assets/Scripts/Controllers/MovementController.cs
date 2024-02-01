using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController
{
    Transform ownerTransform;
    float moveSpeed;
    public MovementController(Transform transform, float speed)
    {
        this.ownerTransform = transform;
        this.moveSpeed = speed;
    }
    public void HandleMovementInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                MoveTowards(touchPosition);
            }
        }
    }
    public void Move(Vector3 destination) => ownerTransform.position = destination;
    public void DirectionalMove(Vector3 dir) => ownerTransform.position += dir * moveSpeed * Time.deltaTime;
    public void MoveTowards(Vector3 destination) => ownerTransform.position = Vector3.MoveTowards(ownerTransform.position, destination, moveSpeed   * Time.deltaTime);
}
