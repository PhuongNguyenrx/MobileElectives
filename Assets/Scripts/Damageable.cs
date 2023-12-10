using System.Collections;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent (typeof(Rigidbody))]
public class Damageable : MonoBehaviour
{
    public float health;
    [SerializeField] Material damagedMaterial;
    [SerializeField] Material originalMaterial;
    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
    
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
