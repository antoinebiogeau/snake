using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SNC : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject segmentPrefab;
    public int delay = 10; // Le délai entre les segments, plus le nombre est grand, plus la distance est grande
    private List<Vector3> positions = new List<Vector3>();
    private Queue<GameObject> segments = new Queue<GameObject>();
    private Vector3 direction = Vector3.forward;
    private int score = 0;
    [SerializeField] private UIManager uimanager;
    private Vector3 lastDirection;
        
        
    void Start()
    {
        segments.Enqueue(this.gameObject); // La tête est le premier segment
        lastDirection = direction;
    }
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && direction != Vector3.back)
        {
            direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && direction != Vector3.forward)
        {
            direction = Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && direction != Vector3.right)
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && direction != Vector3.left)
        {
            direction = Vector3.right;
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void FixedUpdate()
    {
        if (positions.Count > segments.Count * delay)
        {
            positions.RemoveAt(0);
        }
        positions.Add(transform.position);

        // Déplacement de la tête
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Mise à jour des segments
        int segmentIndex = 1;
        foreach (var segment in segments)
        {
            if (segment != gameObject) // Ignorer la tête
            {
                int positionIndex = segmentIndex * delay;
                if (positionIndex < positions.Count)
                {
                    segment.transform.position = positions[positions.Count - 1 - positionIndex];
                    segmentIndex++;
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ITM item = other.GetComponent<ITM>();
        if (item != null)
        {
            item.ApplyEffect(this);
            Destroy(other.gameObject);
            AddSegment();
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
    void AddSegment()
    {
        GameObject segment = Instantiate(segmentPrefab, positions[0], Quaternion.identity);
        segments.Enqueue(segment);
    }
}
