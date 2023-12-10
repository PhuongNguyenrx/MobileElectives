using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    public float bulletDamage;
    public float cooldownCount;
    private void FixedUpdate()
    {
        transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (Screen.width <= screenPosition.x || screenPosition.x <= 0 || Screen.height <= screenPosition.y || screenPosition.y <= 0)
            Destroy(gameObject);
    }
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Damageable>(out Damageable damageable))
        {
            damageable.Damaged(bulletDamage);
            Destroy(gameObject);
        }
    }
}
