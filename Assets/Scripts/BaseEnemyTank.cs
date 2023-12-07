using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyTank : BaseTank
{
    protected Transform playerTransform;
    protected float range = 2f;

    new void Start()
    {
        base.Start();

        // Find the player tank and store its transform
        playerTransform = GameObject.FindGameObjectWithTag("PlayerTank").transform;
    }
    void Update()
    {
        Move();

        UpdateFiringDirection(playerTransform.position);
        Fire();
    }

    // Implement abstract methods
    protected virtual void Move()
    {
        float x = Mathf.PingPong(Time.time * moveSpeed, range * 2) - range;
        transform.Translate(Vector2.left * Time.deltaTime * x);
    }
}
