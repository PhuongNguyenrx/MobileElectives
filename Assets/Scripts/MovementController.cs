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
            Vector3 targetPosition = (touch.position.x < Screen.width / 2) ?
                ownerTransform.position - Vector3.right : ownerTransform.position + Vector3.right;
            targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, -2, 2),targetPosition.y,targetPosition.z);
            if (targetPosition != ownerTransform.position)
                Move(targetPosition);
        }
    }
    public void Move(Vector3 position)
    {
        ownerTransform.position = position;
    }
}
