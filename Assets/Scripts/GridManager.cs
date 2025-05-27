using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

    [SerializeField]
    private int gridWidth, gridHeight;

    [SerializeField]
    private Tile tilePrefab;

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
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = ((x + y) % 2 == 0);
                var isEdge = (x < 2 || x >= gridWidth - 2 || y < 2 || y >= gridHeight - 2);
                spawnedTile.Init(isOffset, isEdge);
                //spawnedTile.Init(isOffset, false);
            }
        }

        cameraTrans.transform.position = new Vector3((float)gridWidth / 2 - .5f, (float)gridHeight / 2 - .5f, -10);
    }
}
