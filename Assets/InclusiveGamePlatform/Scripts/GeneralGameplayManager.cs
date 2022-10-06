using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InclusiveGamePlatform.Core.Patterns.Singleton;
using UnityEngine.Events;

public class GeneralGameplayManager : Singleton<GeneralGameplayManager>
{
    public UnityEvent GameWasStarted;
    public UnityEvent GameWasPaused;
    public UnityEvent GameWasEnded;

    private bool _started = false;

    private PlatformSpawner _platformSpawner;

    [SerializeField]
    private GameConfig _gameConfig;

    private void Awake()
    {
        _platformSpawner = GetComponentInChildren<PlatformSpawner>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !_started)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        _started = true;
        Countdown.Instance.StartTimer(_gameConfig.Time);
        _platformSpawner.SpawnNextPlatform();
        GameWasStarted.Invoke();
    }

    public void PauseGame()
    {
        GameWasPaused.Invoke();
    }

    public void EndGame()
    {
        _started = false;
        GameWasEnded.Invoke();
    }
}