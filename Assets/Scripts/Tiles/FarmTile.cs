using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTile : Tile
{

    [SerializeField]
    private Color baseColour, offsetColour;


    public override void Init(int x, int y)
    {

        var isOffset = ((x + y) % 2 == 0);

        tileRenderer.color = isOffset ? offsetColour : baseColour;

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
