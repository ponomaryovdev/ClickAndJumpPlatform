using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MPUIKIT;
using InclusiveGamePlatform.Core.Patterns.Observer;

public class CountdownDisplay : MonoBehaviour
{
    private MPImage _countdownIcon;
    private TextMeshProUGUI _countdownText;

    private void Awake()
    {
        _countdownText = GetComponentInChildren<TextMeshProUGUI>();
        _countdownIcon = GetComponentInChildren<MPImage>();

        EventHolder<CountdownInfo>.Subscribe(DisplayTime);
    }

    void DisplayTime(CountdownInfo info)
    {
        info.Seconds += 1;
        float minutes = Mathf.FloorToInt(info.Seconds / 60);
        float seconds = Mathf.FloorToInt(info.Seconds % 60);
        _countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
