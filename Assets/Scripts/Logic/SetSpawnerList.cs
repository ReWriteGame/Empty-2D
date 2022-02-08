using UnityEngine;

[RequireComponent(typeof(Spawner))]
public class SetSpawnerList : MonoBehaviour
{
    [SerializeField] private PrefabListData prefabs ;
     private Spawner spawner;

    private void Awake()
    {
        spawner = GetComponent<Spawner>();
        if(prefabs != null) spawner.spawnerObjects.AddRange(prefabs.Prefabs);
    }
}
