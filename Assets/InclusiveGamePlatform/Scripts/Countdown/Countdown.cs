using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPUIKIT;
using TMPro;
using InclusiveGamePlatform.Core.Patterns.Singleton.SingletoneMono;
using UnityEngine.Events;
using InclusiveGamePlatform.Core.Patterns.Observer;

public class Countdown : Singleton<Countdown>
{
    public UnityEvent WasStarted;
    public UnityEvent WasPauseded;
    public UnityEvent TimeIsOut;

    private float _timeRemaining = 0;
    private bool _timerIsRunning = false;

    void Update()
    {
        if (_timerIsRunning)
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
                EventHolder<CountdownInfo>.Notify(new CountdownInfo(_timeRemaining));
            }
            else
            {
                TimeIsOut.Invoke();
                _timeRemaining = 0;
                _timerIsRunning = false;
            }
        }
    }
    

    public void StartTimer()
    {
        _timerIsRunning = true;
    }

    public void PuseTimer()
    {
        _timerIsRunning = false;
    }

    public void Setup(float timeRemaning)
    {
        _timeRemaining = timeRemaning;
    }
}
