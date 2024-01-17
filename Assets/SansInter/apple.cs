using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : FruitITM
{

    [Header("apple")]
    [SerializeField] private Color m_color;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material.color = m_color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
