using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PenManager : MonoBehaviour
{
    public static PenManager Instance;

    private List<ScriptablePen> pens;

    private void Awake()
    {
        Instance = this;

        pens = Resources.LoadAll<ScriptablePen>("Pens").ToList();
    }


    public void SpawnPens()
    {
        Debug.Log("Spawning pens");
        GameManager.Instance.UpdateGameState(GameState.SpawnAnimals);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
