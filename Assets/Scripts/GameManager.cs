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
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnAnimals:
                SpawnAnimals();
                break;
            case GameState.SpawnPens:
                SpawnPens();
                break;
            
            case GameState.Playing:
                break;
            case GameState.Success:
                break;
            case GameState.Fail:
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void SpawnPens()
    {
        Debug.Log("Spawning pens");
    }


    private void SpawnAnimals()
    {
        Debug.Log("Spawning animals");

    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.GenerateGrid);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameState
{
    GenerateGrid,
    SpawnPens,
    SpawnAnimals,
    Playing,
    Success,
    Fail
}