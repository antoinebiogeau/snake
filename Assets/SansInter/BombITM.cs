using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombITM : ITM
{
    public override void ApplyEffect(SNC snake)
    {
        snake.Die();
        Destroy(gameObject);
    }
}
