using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private GameObject _paltformPrefab;

    private void Awake()
    {
        var res = Resources.LoadAsync("Platforms/BasePlatform");
        _paltformPrefab = (GameObject)res.asset;
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
