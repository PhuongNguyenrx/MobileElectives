using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Responsible for moving the player automatically and receiving input.
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    Transform projectile;
    [SerializeField]
    float cooldownCount;
    float shootCooldown;
    int positionIndex = 0;  
    bool turn;

    void Start()
    {
        Input.multiTouchEnabled = false;
        shootCooldown = cooldownCount;
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (Mathf.Abs(positionIndex) == 2)
                turn = !turn;
            positionIndex = turn ? positionIndex -1 : positionIndex+1;
            gameObject.transform.position = Vector3.right * positionIndex;
        }
        if (shootCooldown > 0)
            shootCooldown -= Time.deltaTime;
        else
        {
            shootCooldown = cooldownCount;
            Shoot();
        }
    }

    void Shoot() => Instantiate(projectile, transform.position, Quaternion.identity);
    
}
