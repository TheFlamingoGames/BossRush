using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        NULL,
        PAUSED,
        PLAY,
        DEATH,
        MENU
    }
    GameState gameState = GameState.NULL;

    public static GameManager instance;

    public class OnGameStateChangeArgs : EventArgs{ public GameState gs; }
    public event EventHandler<OnGameStateChangeArgs> OnGameStateChange;

    public void Awake()
    {
        CheckForNewInstance();
    }

    public void Start()
    {
        SetUpGameState();
        SubscribeToInputListeners();
    }

    private void SubscribeToInputListeners()
    {
        InputManager.instance.OnPausePressed += OnPause;
        InputManager.instance.OnBackPressed += OnUnpause;
    }

    void OnPause(object sender, EventArgs e)
    {
        NewState(GameState.PAUSED);
    }

    void OnUnpause(object sender, EventArgs e)
    {
        NewState(GameState.PLAY);
    }

    private void NewState(GameState gs)
    {
        gameState = gs;
        OnGameStateChange?.Invoke(this, new OnGameStateChangeArgs { gs = gameState });
    }

    private void SetUpGameState() 
    {
        NewState(GameState.PLAY);
    }

    void CheckForNewInstance()
    {        
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    public GameState GetGameState()
    {
        return gameState;
    }
}
