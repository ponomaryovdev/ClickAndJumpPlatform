using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Observer;
using InclusiveGamePlatform.Core.Patterns.Singleton.SingletoneMono;

public class Score : Singleton<Score>
{
    public int score = 0;
    public void AddScore(int newScore)
    {
        score += newScore;
        EventHolder<ScoreInfo>.Notify(new ScoreInfo(newScore));
    }
}
