using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitItem : Item
{
    public int scoreValue = 10;

    public override void ApplyEffect(SnakeController snakeController)
    {
        snakeController.AddScore(scoreValue);
        Destroy(gameObject);
    }
}