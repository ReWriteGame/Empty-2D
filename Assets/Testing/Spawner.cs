using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    [SerializeField] private PrefabListData spawnerData;
    [SerializeField] private Transform spawnParent;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private Transform spawnRotation;
    
    [SerializeField] private bool playOnAwake = true;
    [SerializeField] private bool infinity = true;
    [SerializeField] Vector2Int numberOfSpawns = Vector2Int.one;
    [SerializeField] Vector2 delayВetweenSpawns = Vector2.one;

    public UnityEvent startSpawnEvent;
    public UnityEvent stopSpawnEvent;
    public UnityEvent spawnPrefabEvent;

    private Coroutine currentCoroutine;

    private void Awake()
    {
        if (playOnAwake && spawnerData != null) StartSpawn();
    }

    private IEnumerator StartSpawnCor()
    {
        while (infinity)
        {
            SpawnRandomPrefab();
            yield return new WaitForSeconds(Random.Range(delayВetweenSpawns.x, delayВetweenSpawns.y));
        }

        for (int i = 0; i < Random.Range(numberOfSpawns.x, numberOfSpawns.y); i++)
        {
            SpawnRandomPrefab();
            yield return new WaitForSeconds(Random.Range(delayВetweenSpawns.x, delayВetweenSpawns.y));
        }

        stopSpawnEvent?.Invoke();
        yield break;
    }

    public void StartSpawn()
    {
        startSpawnEvent?.Invoke();
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(StartSpawnCor());
    }

    public void StopSpawn()
    {
        stopSpawnEvent?.Invoke();
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);
    }

    public void SpawnRandomPrefab()
    {
        spawnPrefabEvent?.Invoke();
        GameObject prefab = Instantiate(spawnerData.Prefabs[Random.Range(0, spawnerData.Prefabs.Length)], spawnParent);
        if(spawnPosition != null)prefab.transform.position = spawnPosition.position;
        if(spawnRotation != null)prefab.transform.rotation = spawnRotation.rotation;
    }

    // выпадающий список сделать для выбора режима работы 
    // проверки на вылет на - числа в массивах
}
