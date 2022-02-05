using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform spawnParent = null;
    [SerializeField] private Transform spawnPosition = null;
    [SerializeField] private Transform spawnRotation = null;
    
    [SerializeField] private bool firstSpawnWithoutDelay = true;
    [SerializeField] private bool playOnAwake = true;
    [SerializeField] private bool infinity = true;
    [SerializeField] Vector2Int numberOfSpawns = Vector2Int.one;
    [SerializeField] Vector2 delayВetweenSpawns = Vector2.one;

    public List<GameObject> spawnerObjects;

    public UnityEvent startSpawnEvent;
    public UnityEvent stopSpawnEvent;
    public UnityEvent spawnPrefabEvent;
    public UnityEvent endSpawnEvent;
    
    private Coroutine currentCoroutine;
    
    private void Start()
    {
        if (playOnAwake && spawnerObjects.Count > 0) StartSpawn();
    }

    public void StartSpawn()
    {
        startSpawnEvent?.Invoke();
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(StartSpawnCor(Random.Range(numberOfSpawns.x, numberOfSpawns.y)));
    }

    public void StopSpawn()
    {
        stopSpawnEvent?.Invoke();
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
    }

    public void SpawnRandomPrefab()
    {
        SpawnPrefab(Random.Range(0, spawnerObjects.Count));
    }
    
    public void SpawnPrefab(int index)
    {
        FilterSpawnList();
        if (index < 0  || index > spawnerObjects.Count - 1) return;
        if(spawnerObjects.Count > 0)
        {
            spawnPrefabEvent?.Invoke();
            GameObject prefab = Instantiate(spawnerObjects[index], spawnParent);
            if (spawnPosition != null) prefab.transform.position = spawnPosition.position;
            if (spawnRotation != null) prefab.transform.rotation = spawnRotation.rotation;
        }
    }

    private void FilterSpawnList()
    {
        for (int i = spawnerObjects.Count - 1; i >= 0; i--)
            if (spawnerObjects[i] == null) spawnerObjects.RemoveAt(i); 
    }
    
    
    private IEnumerator StartSpawnCor(int sizeSpawnObjects = 0)
    {
        if (sizeSpawnObjects > 0 && firstSpawnWithoutDelay)
        {
            SpawnRandomPrefab();
            sizeSpawnObjects--;
        }

        for (int i = 0; i < sizeSpawnObjects || infinity; i++)
        {
            yield return new WaitForSeconds(Random.Range(delayВetweenSpawns.x, delayВetweenSpawns.y));
            SpawnRandomPrefab();
        }
        
        endSpawnEvent?.Invoke();
        yield break;
    }
    // выпадающий список сделать для выбора режима работы 
}
