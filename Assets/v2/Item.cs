using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IItemEffect
{
    public abstract void ApplyEffect(SnakeController snakeController);
}
