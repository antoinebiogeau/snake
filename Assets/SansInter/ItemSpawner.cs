using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs; 
    public Collider spawnArea; 
    public float spawnInterval = 5f; 

    private void Start()
    {
        StartCoroutine(SpawnItems());
    }

    private IEnumerator SpawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnItem();
        }
    }

    private void SpawnItem()
    {
        Bounds bounds = spawnArea.bounds;
        Vector3 spawnPoint = new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );

        GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
        Instantiate(itemPrefab, spawnPoint, Quaternion.identity);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SNC>().Die();
        }
    }
}
