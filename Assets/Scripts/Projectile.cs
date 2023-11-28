using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed;
    private void FixedUpdate() => transform.position += Vector3.up * bulletSpeed * Time.deltaTime;
    private void OnBecameInvisible() => Destroy(gameObject);
}
