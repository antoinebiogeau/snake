using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombe : items
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Collect(Collider other)
    {
        base.Collect(other);
        other.GetComponent<EhJeSuisLeSnake>().death();
    }
}
