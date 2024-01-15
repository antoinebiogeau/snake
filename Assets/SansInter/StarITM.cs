using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarITM : ITM
{
    public float duration = 10f;
    public float speedMultiplier = 2f;

    public override void ApplyEffect(SNC snake)
    {
        snake.StartCoroutine(snake.ChangeSpeed(speedMultiplier, duration));
    }
}
