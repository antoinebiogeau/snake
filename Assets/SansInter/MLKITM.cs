using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MLKITM : ITM
{
    public float duration = 10f;
    public float scoreMultiplier = 2f;

    public override void ApplyEffect(SNC snake)
    {
        snake.StartCoroutine(snake.ChangeScoreMultiplier(scoreMultiplier, duration));
    }
}
