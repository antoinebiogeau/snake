using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombItem : Item
{
    public override void ApplyEffect(SnakeController snakeController)
    {
        snakeController.GameOver();
        Destroy(gameObject);
    }
}
