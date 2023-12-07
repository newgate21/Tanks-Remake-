using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTank : MonoBehaviour
{
    [SerializeField] protected short hitPoints;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] protected float fireDelay;

    protected Vector2 firingDirection;
    protected TimedDelayer delayerScript;

    protected void Start()
    {
        delayerScript = GetComponent<TimedDelayer>();
    }
    public void UpdateFiringDirection(Vector3 _newFiringPosition)
    {
        // Calculate the direction vector from the current position to the firing position
        firingDirection = (Vector2)(_newFiringPosition - transform.position);
    }
    public void Fire()
    {
        if (projectilePrefab == null) return;
        if (delayerScript == null) return;

        // Check if firing too fast
        if (delayerScript.IsDelayInProgress) return;

        // Start the time delay for firing
        delayerScript.StartDelay(fireDelay);

        // Create a new projectile
        GameObject newProjectile = Instantiate<GameObject>(projectilePrefab, transform.position, transform.rotation, transform);
        newProjectile.transform.SetParent(null);

        // Trigger a firing action
        newProjectile.GetComponent<Projectile>().Fire(firingDirection.normalized);
    }
}
