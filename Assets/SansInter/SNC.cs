using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SNC : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject segmentPrefab;
    public int delay = 10;
    private LinkedList<Vector3> positions = new LinkedList<Vector3>();
    private Queue<GameObject> segments = new Queue<GameObject>();
    private Vector3 direction = Vector3.forward;
    private int score = 0;
    [SerializeField] private UIManager uimanager;
    private Vector3 lastDirection;
    private float scoreMultiplier = 1f;
    public GameObject particleSystemPrefab;


    void Start()
    {
        segments.Enqueue(this.gameObject);
        positions.AddLast(transform.position);
    }
    void Update()
    {
        HandleInput();
    }
    private void FixedUpdate()
    {
        MoveHead();
        UpdateSegments();
    }

    void OnTriggerEnter(Collider other)
    {
        ITM item = other.GetComponent<ITM>();
        if (item != null)
        {
            item.ApplyEffect(this);
            PlayParticleSystem();
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
    GameObject segment = Instantiate(segmentPrefab, positions.Last.Value, Quaternion.identity);
    segments.Enqueue(segment);
}
    
    private void MoveHead()
    {
        transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
        positions.AddLast(transform.position);
        if (positions.Count > segments.Count * delay + 1)
        {
            positions.RemoveFirst();
        }
    }

    private void UpdateSegments()
    {
        int segmentIndex = 1;
        foreach (var segment in segments)
        {
            if (segment != gameObject)
            {
                LinkedListNode<Vector3> node = positions.Last;
                for (int i = 0; i < segmentIndex * delay; ++i)
                {
                    node = node.Previous;
                }
                segment.transform.position = node.Value;
                segmentIndex++;
            }
        }
    }
    private void HandleInput()
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
    }
    protected void PlayParticleSystem()
    {
        if (particleSystemPrefab != null)
        {
            GameObject particleSystemInstance = Instantiate(particleSystemPrefab, transform.position, Quaternion.identity);
            ParticleSystem ps = particleSystemInstance.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
                Destroy(particleSystemInstance, ps.main.duration);
            }
            else
            {
                Destroy(particleSystemInstance);
            }
        }
        else
        {
            Debug.LogError("ParticleSystem prefab is not assigned!");
        }
    }
}
