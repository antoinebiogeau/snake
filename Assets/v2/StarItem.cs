using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarItem : Item
{
    public float speedMultiplier = 2f;
    public float duration = 5f;

    public override void ApplyEffect(SnakeController snakeController)
    {
        snakeController.ChangeSpeed(speedMultiplier, duration);
        Destroy(gameObject);
    }
}