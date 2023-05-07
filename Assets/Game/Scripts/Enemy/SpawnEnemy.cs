using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _objectToInstantiate;
    [SerializeField] private Transform[] _spawnPoints;

    private int lastSpawnPointIndex = -1;

    private void OnEnable()
    {
        SpawnObject();
    }
        
    private void SpawnObject()
    {
        int randomSpawnIndex;
        if (_spawnPoints.Length == 1)
        {
            randomSpawnIndex = 0;
        }
        else
        {
            do
            {
                randomSpawnIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
            } while (randomSpawnIndex == lastSpawnPointIndex);
        }

        lastSpawnPointIndex = randomSpawnIndex;

        GameObject spawnedObject = Instantiate(_objectToInstantiate, _spawnPoints[randomSpawnIndex].position, Quaternion.identity);
        Destroy(spawnedObject, 4f);
    }
}
