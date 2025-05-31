using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    //[SerializeField]
    //private Color baseColour, offsetColour;
    //private Color baseColour, offsetColour, edgeColour;

    [SerializeField]
    protected SpriteRenderer tileRenderer;

    [SerializeField]
    private bool isSpawnable;

    public bool isOccupied;


    //public void Init(bool isOffset, bool isEdge)
    //public void Init(bool isOffset)
    public virtual void Init(int x, int y)
    {

    }


    public bool GetSpawnable()
    {
        return isSpawnable;
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
