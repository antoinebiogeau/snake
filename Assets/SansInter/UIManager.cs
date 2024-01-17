using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
        if(scoretext == null)
        {
            Debug.Log("euh mon reuf asigne le texte");
        }
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int score)
    {
        scoretext.text = $"score : {score}";

    }
}
