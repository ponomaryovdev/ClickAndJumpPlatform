using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "InclusivePlatform/ClickAndJump/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{
    public float Time;
    public WordCollection wordCollection;
}
