using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for player things.
/// </summary>
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] List<Transform> projectiles;
    [SerializeField] float speed = 5;
    float health = 100;

    [SerializeField] AudioClip collisionClip, projectileClip;
    AudioSource audioSource;

    List<ShootController> shootControllers = new();
    MovementController movementController;
    Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
        Input.multiTouchEnabled = false;
        movementController = new MovementController(this.transform,speed);
        foreach (var t in projectiles)
        {
            shootControllers.Add(new ShootController(t.GetComponent<Projectile>(),transform, audioSource, projectileClip));
        }
        GameManager.OnExtraLife += ExtraLife;
    }

    void Update()
    {
        //if (health <= 0)
        //    return;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damaged(10);
    }

    public void Damaged(float damage)
    {
        audioSource.PlayOneShot(collisionClip);
        health -= damage;
        if (health <= 0)
        {
            Die();
            return;
        }
        //Play sound here
    }

    public void IncreaseHealth(float healthToIncrease) => health += healthToIncrease;

    void Die()
    {
        animator.Play("Player_Die");
        GameManager.Instance.GameOver();
    }

    void ExtraLife()
    {
        movementController.Move(Vector3.zero);
        health = 100;
    }
}
