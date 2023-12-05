using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private Rigidbody2D projectilePrefab;
    [SerializeField] private float FireRate;
    [SerializeField] private float TimeBtwShot = 0;

    // Update is called once per frame
    void Update()
    {
        if (TimeBtwShot <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Fire();
                TimeBtwShot = FireRate;
            }
        }
        else
        {
            TimeBtwShot -= Time.deltaTime;
        }
    }

    public void Move(Vector2 _movementVector2)
    {
        transform.Translate(_movementVector2 * MoveSpeed * Time.deltaTime);
    }

    private void Fire()
    {
        Rigidbody2D tProj = Instantiate<Rigidbody2D>(projectilePrefab, transform.position, transform.rotation, transform);
    }
}
