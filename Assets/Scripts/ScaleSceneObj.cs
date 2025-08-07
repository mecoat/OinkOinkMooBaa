using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleSceneObj : MonoBehaviour
{

    private Vector2 screenRes;

    private Camera mainCam;

    private Vector2 gameRatio;

    [SerializeField]
    private GridManager gridManager;

    private Vector2 screenRatio;

    // Start is called before the first frame update
    void Start()
    {

        mainCam = Camera.main;
        screenRes = new Vector2(Screen.width, Screen.height);

        calGameRatio();

        calScreenRatio();

        //scaleSceneView();
    }

    // Update is called once per frame
    void Update()
    {

        //if (screenRes.x != Screen.width || screenRes.y != Screen.height)
        // {
        //   scaleSceneView();

        // screenRes.x = Screen.width;
        // screenRes.y = Screen.height;
        //}

    }

    //private void scaleSceneView()
    public void scaleSceneView()
    {
        //float objToCamDist = Vector3.Distance(gameObject.transform.position, mainCam.transform.position);

        //float objHeightScale = (2.0f * Mathf.Tan(0.5f * mainCam.fieldOfView * Mathf.Deg2Rad) * objToCamDist) / 10.00f;
        //float objWidthScale = (objHeightScale * mainCam.aspect);

        //float objHeightScale = screenRatio.x * (gameRatio.y / gameRatio.x);
        //float objWidthScale = screenRatio.y * (gameRatio.x / gameRatio.y); 

        //float objHeightScale = (screenRatio.x * (gameRatio.y / gameRatio.x)) / gameRatio.x;
        //float objWidthScale = (screenRatio.y * (gameRatio.x / gameRatio.y)) / gameRatio.x;

        float objHeightScale = screenRatio.y / gameRatio.y;
        float objWidthScale = screenRatio.x / gameRatio.x;

        float scaleDivisor = 1;

        if (objWidthScale > objHeightScale)
        {
            scaleDivisor = objHeightScale;
        } 
        else
        {
            scaleDivisor = objWidthScale;
        }

        objWidthScale = objWidthScale / scaleDivisor;
        objHeightScale = objHeightScale / scaleDivisor;


        gameObject.transform.localScale = new Vector3(objWidthScale, objHeightScale, 1);
        //gameObject.transform.localScale = new Vector3(objHeightScale, objWidthScale, 1);

        gameObject.transform.position = new Vector3(0, 0, 0);

        //Camera.main.transform.position = new Vector3((float)gridWidth / 2 - .5f, (float)gridHeight / 2 - .5f, -10);
        //mainCam.transform.position = new Vector3(transform.position.x + gameRatio.x/2, transform.position.y + gameRatio.y/2, -10);
        mainCam.transform.position = new Vector3(2 * objWidthScale, 4 * objHeightScale, -10);
    }

    private void calGameRatio()
    {
        gameRatio.x = gridManager.getGridWidth();
        gameRatio.y = gridManager.getGridHeight();

    }

    private void calScreenRatio()
    {
        screenRatio.x = Screen.width;
        screenRatio.y = Screen.height;

    }
}
