using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkshakeItem : Item
{
    public float scoreMultiplier = 2f;
    public float duration = 5f;

    public override void ApplyEffect(SnakeController snakeController)
    {
        snakeController.ChangeScoreMultiplier(scoreMultiplier, duration);
        Destroy(gameObject);
    }
}