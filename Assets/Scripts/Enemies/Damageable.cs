using System.Collections;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent (typeof(Rigidbody2D))]
public class Damageable : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] Material damagedMaterial;
    [SerializeField] Material originalMaterial;
    
    public void Damaged(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            return;
        }
        //StartCoroutine(FlashDamage());
    }

    public virtual void Die()
    {
        GameManager.Instance.enemyOnScreen.Remove(transform);
        GameManager.Instance.EnemyCheck();
        Destroy(gameObject);
    }
    IEnumerator FlashDamage()
    {
        gameObject.GetComponent<MeshRenderer>().material = damagedMaterial;
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<MeshRenderer>().material = originalMaterial;
    }
}
