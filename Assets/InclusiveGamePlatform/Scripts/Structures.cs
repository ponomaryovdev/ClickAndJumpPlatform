using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public struct KeyBlock
{
    public List<string> keys;

    public KeyBlock(List<string> _keys)
    {
        keys = _keys;
    }
}

