using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _paltformPrefab;

    private void Awake()
    {
    }

    public void SpawnNextPlatform()
    {
        SpawnPlatform(_paltformPrefab);
    }

    private void SpawnPlatform(GameObject paltformPrefab)
    {
        PlatformBase platformTmp = Instantiate(_paltformPrefab).GetComponent<PlatformBase>();
        platformTmp.Init(WordCollector.Instance.GetNextKeyBlock());
    }
}
