using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombITM : ITM
{
    // Start is called before the first frame update
    public override void ApplyEffect(SNC snake)
    {
        // Effet de destruction du serpent et arrêt du jeu
        snake.Die();
        Destroy(gameObject);
    }
}
