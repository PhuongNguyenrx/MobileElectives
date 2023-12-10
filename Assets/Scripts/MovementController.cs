using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController 
{
    Transform ownerTransform;
    public MovementController(Transform transform) => this.ownerTransform = transform;
    public void HandleMovementInput()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2)
                Move(ownerTransform.position - Vector3.right);
            else
                Move(ownerTransform.position + Vector3.right);
        }
    }
    public void Move(Vector3 position)
    {
        ownerTransform.position = position;
    }
}
