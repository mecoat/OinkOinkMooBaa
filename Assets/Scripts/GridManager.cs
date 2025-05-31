using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    private int gridWidth, gridHeight;

    [SerializeField]
    private Tile farmTile, pathTile, edgeTile;

    [SerializeField]
    private Transform cameraTrans;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateGrid()
    {
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
            }
        }

        cameraTrans.transform.position = new Vector3((float)gridWidth / 2 - .5f, (float)gridHeight / 2 - .5f, -10);
    }
}
