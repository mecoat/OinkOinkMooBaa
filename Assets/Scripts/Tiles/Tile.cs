using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private Color baseColour, offsetColour;
    //private Color baseColour, offsetColour, edgeColour;

    [SerializeField]
    private SpriteRenderer tileRenderer;

    //public void Init(bool isOffset, bool isEdge)
    public void Init(bool isOffset)
    {
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
