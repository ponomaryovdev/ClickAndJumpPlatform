using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Observer;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    private void Awake()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
        EventHolder<ScoreInfo>.Subscribe(AddScoreEvent);
    }

    private void AddScoreEvent(ScoreInfo score)
    {
        _scoreText.text = Score.Instance.score.ToString();
    }
}