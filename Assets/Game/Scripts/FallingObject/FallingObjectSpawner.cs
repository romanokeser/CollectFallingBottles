using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToInstantiate;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float speed = 1f;

    private float spawnTimer = 0f;

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 1f / speed)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    private void SpawnObject()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);

        GameObject spawnedObject = Instantiate(objectToInstantiate, spawnPoints[randomSpawnIndex].position, Quaternion.identity);
        Destroy(spawnedObject, 2f);
    }
}
