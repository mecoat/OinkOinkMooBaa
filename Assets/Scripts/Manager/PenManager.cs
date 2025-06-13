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

    public void SpawnPen(PensToSpawn pen)
    {
        //Debug.Log("Spawning " + pen.pen + " @ " + pen.spawnSite + " with " + pen.noAnimals.ToString() + " animals");
        //Debug.Log("Spawning " + " @ " + pen.spawnSite + " with " + pen.noAnimals.ToString() + " animals");


        var spawnedPen = Instantiate(pen.pen.penPrefab);


        if (pen.spawnSite == SpawnSite.leftWhole)
        {
            spawnedPen.transform.localScale = new Vector3(2f, GridManager.Instance.getGridHeight() - 2f, 0f);
            spawnedPen.transform.position = new Vector3(-0.5f, (GridManager.Instance.getGridHeight() / 2) - 0.5f, 0f);
        } 
        else if (pen.spawnSite == SpawnSite.rightWhole)
        {
            spawnedPen.transform.localScale = new Vector3(2f, GridManager.Instance.getGridHeight() - 2f, 0f);
            spawnedPen.transform.position = new Vector3(GridManager.Instance.getGridWidth() - 0.5f, (GridManager.Instance.getGridHeight() / 2) - 0.5f, 0f);
        }
        else if (pen.spawnSite == SpawnSite.top)
        {
            spawnedPen.transform.localScale = new Vector3(GridManager.Instance.getGridWidth(), 2f, 0f);
            spawnedPen.transform.position = new Vector3((GridManager.Instance.getGridWidth() / 2) - 0.5f, GridManager.Instance.getGridHeight() - 0.5f, 0f);
        }
        else if (pen.spawnSite == SpawnSite.bottom)
        {
            spawnedPen.transform.localScale = new Vector3(GridManager.Instance.getGridWidth(), 2f, 0f);
            spawnedPen.transform.position = new Vector3((GridManager.Instance.getGridWidth() / 2) - 0.5f, -0.5f, 0f);
        }
        else if (pen.spawnSite == SpawnSite.leftBottom)
        {
            spawnedPen.transform.localScale = new Vector3(2f, (GridManager.Instance.getGridHeight() -2) / 2f , 0f);
            spawnedPen.transform.position = new Vector3(-0.5f, GridManager.Instance.getGridHeight() / 4, 0f);
        }
        else if (pen.spawnSite == SpawnSite.rightBottom)
        {
            spawnedPen.transform.localScale = new Vector3(2f, (GridManager.Instance.getGridHeight() - 2) / 2f, 0f);
            spawnedPen.transform.position = new Vector3(GridManager.Instance.getGridWidth() - 0.5f, GridManager.Instance.getGridHeight() / 4, 0f);
        }
        else if (pen.spawnSite == SpawnSite.leftTop)
        {
            spawnedPen.transform.localScale = new Vector3(2f, (GridManager.Instance.getGridHeight() - 2) / 2f, 0f);
            spawnedPen.transform.position = new Vector3(-0.5f, (GridManager.Instance.getGridHeight() / 4) * 3f -1, 0f);
        }
        else if (pen.spawnSite == SpawnSite.rightTop)
        {
            spawnedPen.transform.localScale = new Vector3(2f, (GridManager.Instance.getGridHeight() - 2) / 2f, 0f);
            spawnedPen.transform.position = new Vector3(GridManager.Instance.getGridWidth() - 0.5f, (GridManager.Instance.getGridHeight() / 4) * 3f - 1, 0f);
        }

        spawnedPen.noAnimals = pen.noAnimals;
        spawnedPen.targetAnimal = pen.pen.Animal.animalPrefab.gameObject;
    }

    //public void SpawnPens()
    //{
    //  Debug.Log("Spawning pens");
    //GameManager.Instance.UpdateGameState(GameState.SpawnAnimals);
    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
