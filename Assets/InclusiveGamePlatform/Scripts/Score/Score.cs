using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Observer;

public class Score : MonoBehaviour
{
    public int ScoreCount;

    public void AddScore(int score)
    {
        ScoreCount += score;
        EventHolder<ScoreInfo>.Notify(new ScoreInfo(ScoreCount));
    }
}
