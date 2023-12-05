using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float ProjectileSpeed = 20;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 _direction)
    {
        // Check if the projectile has a Rigidbody component
        if (rigidBody == null) return;

        // Apply force to shoot the projectile
        rigidBody.AddForce(_direction * ProjectileSpeed, ForceMode2D.Impulse);
    }
}
