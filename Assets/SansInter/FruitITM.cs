using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitITM : ITM
{
    //j'ai ajout� la couleur dans les class enfant mais en vrai j'avais aucune id�e de quoi mettre de plus parce qu'il suffit de faire des prefab en changeant la score 
    public int scoreAmount = 10;

    public override void ApplyEffect(SNC snake)
    {
        snake.AddScore(scoreAmount);
    }
}
