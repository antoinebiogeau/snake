using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public GameObject[] items;
    public float spawnInterval = 5f;
    public BoxCollider spawnArea;

    void Start()
    {
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    void SpawnItem()
    {
        Vector3 spawnPosition = RandomPointInBounds(spawnArea.bounds);

        int randomIndex = Random.Range(0, items.Length);
        Instantiate(items[randomIndex], spawnPosition, Quaternion.identity);
    }

    Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
}
