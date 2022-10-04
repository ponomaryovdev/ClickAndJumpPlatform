using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPUIKIT;
using TMPro;
using InclusiveGamePlatform.Core.Patterns.Observer;


public class ScoreDisplay : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    private MPImage _scoreIcon;

    private void Awake()
    {
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();
        _scoreIcon = GetComponentInChildren<MPImage>();

        EventHolder<ScoreInfo>.Subscribe(ScoreUpdate);
    }

    private void ScoreUpdate(ScoreInfo info)
    {
        _scoreText.text = info.Score.ToString();

        LeanTween.scale(_scoreIcon.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.2f).setOnComplete(delegate ()
        {
            LeanTween.scale(_scoreIcon.gameObject, new Vector3(1.0f, 1.0f, 1.0f), 0.2f);
        });
    }
}
