using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    protected virtual void Collect(Collider other)
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Collect(other);
    }
}
