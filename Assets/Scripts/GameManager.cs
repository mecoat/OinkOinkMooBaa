using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;


        switch (newState)
        {
            case GameState.Spawning:
                SpawnAnimals();
                break;
            case GameState.Playing:
                break;
            case GameState.Success:
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void SpawnAnimals()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Spawning);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameState
{
    Spawning,
    Playing,
    Success
}