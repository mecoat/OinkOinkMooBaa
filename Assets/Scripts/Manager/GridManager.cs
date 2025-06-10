using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{

    public static GridManager Instance;

    [SerializeField]
    private int gridWidth, gridHeight;

    [SerializeField]
    private Tile farmTile, pathTile, edgeTile;

    [SerializeField]
    private Transform cameraTrans;

    private Dictionary<Vector2, Tile> farmTiles;
    private List<Vector2> farmTilesKeys;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        farmTiles = new Dictionary<Vector2, Tile>();


        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Tile selectedTile;

                if (x == 0 || x == gridWidth - 1 || y ==0 || y == gridHeight - 1)
                {
                    selectedTile = edgeTile;
                }
                else if (x == 1 || x == gridWidth - 2 || y == 1 || y == gridHeight - 2)
                {
                    selectedTile = pathTile;
                }
                else
                {
                    selectedTile = farmTile;
                }

                var spawnedTile = Instantiate(selectedTile, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                //var isEdge = (x < 2 || x >= gridWidth - 2 || y < 2 || y >= gridHeight - 2);
                //spawnedTile.Init(isOffset, isEdge);
                //spawnedTile.Init(isOffset);
                spawnedTile.Init(x,y);
                //spawnedTile.Init(isOffset, false);
                if (spawnedTile.GetSpawnable())
                {
                    farmTiles[new Vector2(x, y)] = spawnedTile;
                }
            }
        }

        farmTilesKeys = farmTiles.Keys.ToList();

        cameraTrans.transform.position = new Vector3((float)gridWidth / 2 - .5f, (float)gridHeight / 2 - .5f, -10);

        GameManager.Instance.UpdateGameState(GameState.SpawnPens);
    }

    public Tile GetSpawnTile()
    {
        //return farmTiles.OrderBy(tiles => Random.value).First().value;
        //return farmTiles.Where(t=>t.key.x <width).OrderBy(t=>Random.value).First().value;
        Vector2 randKey = farmTilesKeys[Random.Range(0, farmTilesKeys.Count)];
        Debug.Log("spawn tle = " + farmTiles[randKey]);

        Tile randTile = farmTiles[randKey];


        if (randTile.isOccupied)
        {
            randTile = GetSpawnTile();
        }


        return randTile;
    }

    public int getGridHeight()
    {
        return (gridHeight);
    }

    public int getGridWidth()
    {
        return gridWidth;
    }
}
