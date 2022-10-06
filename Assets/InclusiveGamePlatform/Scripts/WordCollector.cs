using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Singleton.SingletoneMono;
using InclusiveGamePlatform.Core.Patterns.Observer;
using UnityEngine.Events;

public class WordCollector : Singleton<WordCollector>
{
    public WordCollection wordCollection = null;
    public KeyBlock _currentKeyBlock;
    public string _currentKey;
    public int _currentKeyBlockId = -1;
    public int _currentKeyId = 0;
    public UnityEvent TrueKeyWasDetected;
    public UnityEvent FalseKeyWasDetected;
    public UnityEvent BlockWasFinished;
    public bool wordEnd;

    private GeneralGameplayManager _generalGameplayManager;

    private void Awake()
    {
        _generalGameplayManager = GetComponentInParent<GeneralGameplayManager>();
    }

    private void OnEnable()
    {
        EventHolder<KeyDetectionInfo>.Subscribe(DetectNewKeyPressed);
    }

    private void OnDisable()
    {
        EventHolder<KeyDetectionInfo>.Unsubscribe(DetectNewKeyPressed);
    }


    public KeyBlock GetNextKeyBlock()
    {
        _currentKeyBlock = wordCollection.keyBlocks[_currentKeyBlockId++];
        _currentKeyId = 0;
        _currentKey = _currentKeyBlock.keys[_currentKeyId];
        return _currentKeyBlock;
    }

    private void DetectNewKeyPressed(KeyDetectionInfo newKeyInfo)
    {
        if (_currentKeyId >= _currentKeyBlock.keys.Count)
            return;

        string newKey = newKeyInfo.Key;

        if (newKey == "Null")
            return;

        if(_currentKey == newKey)
        {
            TrueKeyWasDetected.Invoke();
            Score.Instance.AddScore(1);

            _currentKeyId++;

            if (_currentKeyId == _currentKeyBlock.keys.Count)
            {
                if (_currentKeyBlockId == wordCollection.keyBlocks.Count)
                {
                    _generalGameplayManager.EndGame();
                    return; 
                }

                BlockWasFinished.Invoke();
                _currentKey = _currentKeyBlock.keys[_currentKeyId];
            }
            else
            {
                _currentKey = _currentKeyBlock.keys[_currentKeyId];
            }

        }
        else
        {
            FalseKeyWasDetected.Invoke();
        }
    }
}