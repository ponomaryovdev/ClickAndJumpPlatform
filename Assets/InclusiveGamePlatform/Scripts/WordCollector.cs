using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Singleton.SingletoneMono;

public class WordCollector : Singleton<WordCollector>
{
    public WordCollection wordCollection = null;
    public KeyBlock _currentKeyBlock;
    public int _currentKeyBlockId = -1;

    public KeyBlock GetNextKeyBlock()
    {
        _currentKeyBlock = wordCollection.keyBlocks[_currentKeyBlockId++];
        return _currentKeyBlock;
    }

}
