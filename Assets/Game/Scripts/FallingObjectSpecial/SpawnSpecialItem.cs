using UnityEngine;

public class SpawnSpecialItem : MonoBehaviour
{
    [SerializeField] private GameObject _objectToInstantiate;
    [SerializeField] private Transform[] _spawnPoints;

    private void OnEnable()
    {
        SpawnObject();
    }

    private void SpawnObject()
    {
        int randomSpawnIndex = Random.Range(0, _spawnPoints.Length);

        GameObject spawnedObject = Instantiate(_objectToInstantiate, _spawnPoints[randomSpawnIndex].position, Quaternion.identity);
        Destroy(spawnedObject, 2f);
    }
}
