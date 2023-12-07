using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : BaseTank
{ 
    public void Move(Vector2 _movementVector2)
    {
        transform.Translate(_movementVector2 * moveSpeed * Time.deltaTime);
    }
}
