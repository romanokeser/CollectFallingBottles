using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private Transform[] spawnPoints;
    public float FrequencySpawning = 1f;

    private float spawnTimer = 0f;
    private int lastSpawnPointIndex = -1;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 1f / FrequencySpawning)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    private void SpawnObject()
    {
        int randomSpawnIndex;
        if (spawnPoints.Length == 1)
        {
            randomSpawnIndex = 0;
        }
        else
        {
            do
            {
                randomSpawnIndex = Random.Range(0, spawnPoints.Length);
            } while (randomSpawnIndex == lastSpawnPointIndex);
        }

        lastSpawnPointIndex = randomSpawnIndex;

        GameObject spawnedObject = Instantiate(objectToInstantiate, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
        Destroy(spawnedObject, 2f);
    }
}
