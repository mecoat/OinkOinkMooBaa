using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    private List<ScriptablePen> pens;

    private List<PensToSpawn> pensToSpawn;

    [SerializeField]
    private GameObject sceneHolder;

    private void Awake()
    {
        Instance = this;

        pens = Resources.LoadAll<ScriptablePen>("Pens").ToList();
        //Debug.Log("pens " + pens[0]);

    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;


        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnPens:
                foreach (PensToSpawn pen in pensToSpawn)
                {
                    PenManager.Instance.SpawnPen(pen);
                }

                //PenManager.Instance.SpawnPens();

                UpdateGameState(GameState.SpawnAnimals);

                break;
            case GameState.SpawnAnimals:

                for (var i = 0; i < pensToSpawn.Count; i++)
                {
                    AnimalManager.Instance.SpawnAnimal(pensToSpawn[i].pen.Animal, pensToSpawn[i].noAnimals);

                }

                sceneHolder.GetComponent<ScaleSceneObj>().scaleSceneView();

                UpdateGameState(GameState.Playing);

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


    // Start is called before the first frame update
    void Start()
    {
        pensToSpawn = new List<PensToSpawn> {};
        //Debug.Log("list = " + pensToSpawn[0].pen + " " + pensToSpawn[0].spawnSite + " " + pensToSpawn[0].noAnimals.ToString());

        pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.leftWhole, noAnimals = 2 });
        pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.rightWhole, noAnimals = 3 });
        pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.top, noAnimals = 1 });
        pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.bottom, noAnimals = 2 });
        //pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.leftTop, noAnimals = 1 });
        //pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.leftBottom, noAnimals = 3 });
        //pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.rightTop, noAnimals = 2 });
        //pensToSpawn.Add(new PensToSpawn { pen = pens[Random.Range(0, pens.Count - 1)], spawnSite = SpawnSite.rightBottom, noAnimals = 1 });

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

