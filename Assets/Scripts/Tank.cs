using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float FireDelay;

    private Vector2 firingDirection;
    private TimedDelayer delayerScript;

    private void Start()
    {
        delayerScript = GetComponent<TimedDelayer>();
    }

    public void Move(Vector2 _movementVector2)
    {
        transform.Translate(_movementVector2 * MoveSpeed * Time.deltaTime);
    }

    public void UpdateFiringDirection(Vector3 _newFiringPosition)
    {
        // Calculate the direction vector from the current position to the firing position
        firingDirection = Vector3.Normalize(_newFiringPosition - transform.position);
    }
    public void Fire()
    {
        // Check if prefab exists
        if (projectilePrefab == null) return;
   
        if (delayerScript != null)
        {
            // Check if firing too fast
            if (delayerScript.IsDelayInProgress) return;
            
            // Start the time delay for firing
            delayerScript.StartDelay(FireDelay);
        }

        // Create a new projectile
        GameObject newProjectile = Instantiate<GameObject>(projectilePrefab, transform.position, transform.rotation, transform);
        newProjectile.transform.SetParent(null);

        // Get the rigidbody component of the projectile
        Rigidbody2D projectileRb = newProjectile.GetComponent<Rigidbody2D>();

        // Check if the projectile has a Rigidbody component
        if (projectileRb != null)
        {
            // Apply force to shoot the projectile
            projectileRb.AddForce(firingDirection * newProjectile.GetComponent<Projectile>().ProjectileSpeed, ForceMode2D.Impulse);
        }
    }
}
