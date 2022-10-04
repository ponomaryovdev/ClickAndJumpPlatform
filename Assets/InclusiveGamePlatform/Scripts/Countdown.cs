using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPUIKIT;
using TMPro;
using InclusiveGamePlatform.Core.Patterns.Singleton.SingletoneMono;
using UnityEngine.Events;

public class Countdown : Singleton<Countdown>
{
    public UnityEvent WasStart;
    public UnityEvent WasPaused;
    public UnityEvent TimeIsOut;

    private MPImage _countDownIcon;
    private TextMeshProUGUI _countdownText;

    private void Awake()
    {
        _countDownIcon = GetComponentInChildren<MPImage>();
        _countdownText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    private void Start()
    {

    }
    
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                TimeIsOut.Invoke();
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void PuseTimer()
    {
        timerIsRunning = false;
    }
}
