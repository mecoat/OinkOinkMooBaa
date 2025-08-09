using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScene : MonoBehaviour
{

    [SerializeField]
    private Camera mainCam;

    private Vector3 bottomLeft;
    private Vector3 topRight;

    private Vector3 screenSize;

    private float screenRatio;

    private float desiredRatio; 


    // Start is called before the first frame update
    void Start()
    {
        bottomLeft = mainCam.ViewportToWorldPoint(Vector3.zero) * 100;
        topRight = mainCam.ViewportToWorldPoint(new Vector3(mainCam.rect.width, mainCam.rect.height)) * 100;

        screenSize = topRight - bottomLeft;

        screenRatio = screenSize.x / screenSize.y;
        
        desiredRatio = transform.localScale.x / transform.localScale.y;

        if (screenRatio > desiredRatio)
        {
            float height = screenSize.y;
            //transform.localScale = new Vector3(height * desiredRatio, height);
        }
        else
        {
            float width = screenSize.x;
            //transform.localScale = new Vector3(width, width / desiredRatio);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (screenRatio > desiredRatio)
        {
            float height = screenSize.y;
           // transform.localScale = new Vector3(height * desiredRatio, height);
        }
        else
        {
            float width = screenSize.x;
          //  transform.localScale = new Vector3(width, width / desiredRatio);
        }
    }
}
