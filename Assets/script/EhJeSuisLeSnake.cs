using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EhJeSuisLeSnake : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector3 direction = Vector3.right;
    private int score = 0;

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
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void addPoints(int points)
    {
        score += points;
        Debug.Log(points);
    }
    public void death()
    {
        Destroy(gameObject);
    }
}
