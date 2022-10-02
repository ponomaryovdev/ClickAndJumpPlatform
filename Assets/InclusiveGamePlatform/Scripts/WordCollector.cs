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

    private void Awake()
    {
        EventHolder<KeyDetectionInfo>.Subscribe(DetectNewKeyPressed);
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
            Debug.Log("True key");
            TrueKeyWasDetected.Invoke();

            _currentKeyId++;

            if (_currentKeyId == _currentKeyBlock.keys.Count)
            {
                Debug.Log("Finish block");
                BlockWasFinished.Invoke();
            }
            else
            {
                _currentKey = _currentKeyBlock.keys[_currentKeyId];
            }

        }
        else
        {
            Debug.Log("False key");
            FalseKeyWasDetected.Invoke();
        }
    }
}