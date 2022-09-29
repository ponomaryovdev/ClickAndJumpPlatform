using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordCollection", menuName = "Word/WordCollection", order = 1)]
public class WordCollection : ScriptableObject
{
    public List<KeyBlock> keyBlocks = new List<KeyBlock>();
}
