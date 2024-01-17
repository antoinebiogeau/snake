using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kiwi : FruitITM
{
    [Header("kiwi")]
    [SerializeField] private Color m_color;
    void Start()
    {

        GetComponent<Renderer>().material.color = m_color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
