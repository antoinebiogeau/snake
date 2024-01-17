using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SNC : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3 direction = Vector3.forward;
    private int score = 0;
    [SerializeField] private UIManager uimanager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) direction = Vector3.forward;
        if (Input.GetKeyDown(KeyCode.DownArrow)) direction = Vector3.back;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) direction = Vector3.left;
        if (Input.GetKeyDown(KeyCode.RightArrow)) direction = Vector3.right;

        // Mouvement du serpent
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        ITM item = other.GetComponent<ITM>();
        if (item != null)
        {
            item.ApplyEffect(this);
            Destroy(other.gameObject);
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
    public IEnumerator ChangeSpeed(float multiplier, float duration)
    {
        speed *= multiplier;
        yield return new WaitForSeconds(duration);
        speed /= multiplier;
    }
    private float scoreMultiplier = 1f;

    public IEnumerator ChangeScoreMultiplier(float multiplier, float duration)
    {
        scoreMultiplier *= multiplier;
        yield return new WaitForSeconds(duration);
        scoreMultiplier /= multiplier;
    }

    public void AddScore(int amount)
    {
        int finalScore = Mathf.RoundToInt(amount * scoreMultiplier);
        score += finalScore;
        Debug.Log("Score: " + score);
        uimanager.UpdateScore(score);
    }  
}
