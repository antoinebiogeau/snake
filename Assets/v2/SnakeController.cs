using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
     public float moveSpeed = 2.0f;
    public Transform segmentPrefab;
    public int initialSize = 4;

    private Vector3 direction = Vector3.forward;
    private List<Transform> segments;
    private float scoreMultiplier = 1.0f;
    private float speedMultiplier = 1.0f;

    void Start()
    {
        segments = new List<Transform>();
        ResetState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Vector3.forward;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Vector3.back;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Vector3.left;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Vector3.right;
    }

    void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        float moveSpeedAdjusted = moveSpeed * speedMultiplier;
        this.transform.position += direction * moveSpeedAdjusted * Time.fixedDeltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            // Assuming the item script implements an interface or abstract class
            IItemEffect itemEffect = other.GetComponent<IItemEffect>();
            itemEffect?.ApplyEffect(this);
        }
        else if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void ResetState()
    {
        direction = Vector3.forward;
        this.transform.position = Vector3.zero;
        speedMultiplier = 1.0f;
        scoreMultiplier = 1.0f;

        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        for (int i = 1; i < initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }
    }

    public void AddScore(int amount)
    {
        int finalScore = Mathf.FloorToInt(amount * scoreMultiplier);
        // Add score logic here, update UI, etc.
    }

    public void DoubleSpeed(float duration)
    {
        StartCoroutine(ChangeSpeedTemporarily(2.0f, duration));
    }

    public void GameOver()
    {
        // Game over logic here, like displaying game over screen, resetting the level, etc.
        ResetState();
    }

    public void DoubleFruitScore(float duration)
    {
        StartCoroutine(ChangeScoreMultiplierTemporarily(2.0f, duration));
    }

    private IEnumerator ChangeSpeedTemporarily(float multiplier, float duration)
    {
        speedMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        speedMultiplier = 1.0f;
    }

    private IEnumerator ChangeScoreMultiplierTemporarily(float multiplier, float duration)
    {
        scoreMultiplier = multiplier;
        yield return new WaitForSeconds(duration);
        scoreMultiplier = 1.0f;
    }
    public void ChangeSpeed(float multiplier, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(multiplier, duration));
    }

    private IEnumerator ChangeSpeedCoroutine(float multiplier, float duration)
    {
        moveSpeed *= multiplier;
        yield return new WaitForSeconds(duration);
        moveSpeed /= multiplier;
    }
    public void ChangeScoreMultiplier(float multiplier, float duration)
    {
        StartCoroutine(ChangeScoreMultiplierCoroutine(multiplier, duration));
    }

    private IEnumerator ChangeScoreMultiplierCoroutine(float multiplier, float duration)
    {
        scoreMultiplier *= multiplier;
        yield return new WaitForSeconds(duration);
        scoreMultiplier /= multiplier;
    }

}
