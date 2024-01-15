using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitITM : ITM
{
    public int scoreAmount = 10;

    public override void ApplyEffect(SNC snake)
    {
        snake.AddScore(scoreAmount);
    }
}
