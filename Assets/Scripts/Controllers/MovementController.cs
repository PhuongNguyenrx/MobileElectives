using UnityEngine;

public class MovementController 
{
    Transform ownerTransform;
    float moveSpeed;

    Vector2 touchStartPos;
    bool isMoving;
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
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    StartMoving(touch.position);
                    break;

                case TouchPhase.Moved:
                    if (isMoving)
                    {
                        Vector2 touchDelta = touch.position - touchStartPos;
                        Vector3 newPosition = ownerTransform.position + new Vector3(touchDelta.x, touchDelta.y, 0) * moveSpeed * Time.deltaTime;
                        DirectionalMove(newPosition);
                    }
                    break;

                case TouchPhase.Ended:
                    StopMoving();
                    break;
            }
        }
    }

    void StartMoving(Vector2 startPos)
    {
        touchStartPos = startPos;
        isMoving = true;
    }

    void StopMoving()
    {
        isMoving = false;
    }
    //public void Move(Vector3 destination)
    //{
    //    ownerTransform.position =   Vector3.MoveTowards(ownerTransform.position, destination, moveSpeed * Time.deltaTime);
    //}
    public void DirectionalMove(Vector3 dir) => ownerTransform.position += dir * moveSpeed * Time.deltaTime;
}
