using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Singleton;

public class PlatformSpawner : MonoBehaviour
{
    public int multiplayer = 3;
    
    public Transform PlatformHolder = null;
    public GameObject _paltformPrefab = null;

    private GameObject _previosPlatform = null;
    private GameObject _currentPlatform = null;
    private CalculateVelocity _calculateVelocity = null;

    public bool randomize = false;

    private void Awake()
    {
        _calculateVelocity = FindObjectOfType<CalculateVelocity>();

        WordCollector.Instance.BlockWasFinished.AddListener(BlockWasFinishedEvent);
    }

    public void BlockWasFinishedEvent()
    {
        if(!WordCollector.Instance.wordEnd)
            SpawnNextPlatform();
    }

    public void SpawnNextPlatform()
    {
        SpawnPlatform(_paltformPrefab);
    }

    private void SpawnPlatform(GameObject paltformPrefab)
    {
        if (_currentPlatform)
            _currentPlatform.GetComponent<PlatformBase>().DeactivatePlatform();

        if (_currentPlatform)
            _previosPlatform = _currentPlatform;
        else
            _previosPlatform = gameObject;

        _currentPlatform = Instantiate(_paltformPrefab);
        PlatformBase platformTmp = _currentPlatform.GetComponent<PlatformBase>();

        if (randomize)
        {
            platformTmp.Init(WordCollector.Instance.GetNextKeyBlockRandom());
        }
        else
        {
            platformTmp.Init(WordCollector.Instance.GetNextKeyBlock());
        }

        platformTmp.transform.position = new Vector3(_previosPlatform.transform.position.x + platformTmp.SpriteList.Count * multiplayer, _previosPlatform.transform.position.y, _previosPlatform.transform.position.z);
        platformTmp.ActivatePlatform();
        _calculateVelocity.MoveToPoint(platformTmp.transform.position);
    }
}
