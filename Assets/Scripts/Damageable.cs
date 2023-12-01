using System.Collections;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class Damageable : MonoBehaviour
{
    public float health;
    [SerializeField] float moveSpeed;
    [SerializeField] Material damagedMaterial;
    [SerializeField] Material originalMaterial;
    private void OnBecameInvisible() => Destroy(gameObject);
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
    
    protected void Move(Vector3 dir) => transform.position += dir * moveSpeed * Time.deltaTime;
    public void Damaged(float damage)
    {
        health -= damage;
        StartCoroutine(FlashDamage());
    }
    IEnumerator FlashDamage()
    {
        gameObject.GetComponent<MeshRenderer>().material = damagedMaterial;
        yield return new WaitForSeconds(0.15f);
        gameObject.GetComponent<MeshRenderer>().material = originalMaterial;
    }
}
