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

    private void Awake()
    {
        mainCam = Camera.main;
        screenRes = new Vector2(Screen.width, Screen.height);

        //Debug.Log("campos " + mainCam.transform.position);

    }

    // Start is called before the first frame update
    void Start()
    {

       // mainCam = Camera.main;
        //screenRes = new Vector2(Screen.width, Screen.height);

        //Debug.Log("campos " + mainCam.transform.position);

        //calGameRatio();

        //calScreenRatio();

        //Debug.Log(gameRatio);
        //Debug.Log(screenRatio);

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
        calGameRatio();

        calScreenRatio();

        //Debug.Log(gameRatio);
        //Debug.Log(screenRatio);

        //float objToCamDist = Vector3.Distance(gameObject.transform.position, mainCam.transform.position);

        //float objHeightScale = (2.0f * Mathf.Tan(0.5f * mainCam.fieldOfView * Mathf.Deg2Rad) * objToCamDist) / 10.00f;
        //float objWidthScale = (objHeightScale * mainCam.aspect);

        //float objHeightScale = screenRatio.x * (gameRatio.y / gameRatio.x);
        //float objWidthScale = screenRatio.y * (gameRatio.x / gameRatio.y); 

        //float objHeightScale = (screenRatio.x * (gameRatio.y / gameRatio.x)) / gameRatio.x;
        //float objWidthScale = (screenRatio.y * (gameRatio.x / gameRatio.y)) / gameRatio.x;

        //Debug.Log(gameRatio);
        //Debug.Log(screenRatio);

        float objHeightTo16 = 16 / gameRatio.y;
        //float objWidthTo8 = 8 / gameRatio.x;

        //float objHeightTo16 = gameRatio.y / 16;
        //float objWidthTo8 = gameRatio.x / 8;

        mainCam.orthographicSize = mainCam.orthographicSize / objHeightTo16;

        Debug.Log(mainCam.orthographicSize * 2.0 * Screen.width / Screen.height);

        double camWidth = mainCam.orthographicSize * 2.0 * Screen.width / Screen.height;

        //Debug.Log(objHeightTo16);
        //Debug.Log(objWidthTo8);

        ///>>>>
        //float objHeightScale = screenRatio.y / gameRatio.y;
        //float objWidthScale = screenRatio.x / gameRatio.x;
        double objWidthScale = camWidth / gameRatio.x;
        float objWidthFloat = (float)objWidthScale;

        //float objHeightScale = screenRatio.y / (gameRatio.y * objHeightTo16);
        //float objWidthScale = screenRatio.x / (gameRatio.x * objWidthTo8);

        //float objHeightScale = screenRatio.y / (gameRatio.y / objHeightTo16);
        //float objWidthScale = screenRatio.x / (gameRatio.x / objWidthTo8);

        //Debug.Log("wide " + objWidthScale);
        //Debug.Log("high " + objHeightScale);

        ////>>>>>
        //float scaleDivisor;
        //if (objWidthScale > objHeightScale)
        //{
        //scaleDivisor = objHeightScale;
        //} 
        //else
        //{
        //scaleDivisor = objWidthScale;
        //}
        //scaleDivisor = objWidthTo8;
        //scaleDivisor = 1;

        //Debug.Log("div " + scaleDivisor);


        ///>>>
        //objWidthScale = objWidthScale / scaleDivisor;
        //objHeightScale = objHeightScale / scaleDivisor;

        //objWidthScale = (objWidthScale / scaleDivisor) * objWidthTo8;
        //objHeightScale = (objHeightScale / scaleDivisor) * objHeightTo16;

        //objWidthScale = (objWidthScale * objWidthTo8) / scaleDivisor;
        //objHeightScale = (objHeightScale * objHeightTo16) / scaleDivisor;

        ///>>>
        //gameObject.transform.localScale = new Vector3(objWidthScale, objHeightScale, 1);
        //gameObject.transform.localScale = new Vector3(objWidthScale, 1, 1);
        gameObject.transform.localScale = new Vector3(objWidthFloat, 1, 1);
        //gameObject.transform.localScale = new Vector3(objHeightScale, objWidthScale, 1);

        gameObject.transform.position = new Vector3(0, 0, 0);

        //Camera.main.transform.position = new Vector3((float)gridWidth / 2 - .5f, (float)gridHeight / 2 - .5f, -10);
        //mainCam.transform.position = new Vector3(transform.position.x + gameRatio.x/2, transform.position.y + gameRatio.y/2, -10);
        //mainCam.transform.position = new Vector3(2 * objWidthScale, 4 * objHeightScale, -10);
        //mainCam.transform.position = new Vector3((gameRatio.x / 4) * objWidthScale, (gameRatio.y / 4) * objHeightScale, -10);
        //mainCam.transform.position = new Vector3(transform.position.x + (gameRatio.x/ 2 * objWidthScale), transform.position.y + (gameRatio.y/2 * objHeightScale), -10);
        //mainCam.transform.position = new Vector3((gameRatio.x / 2) * objWidthScale, (gameRatio.y / 2) * objHeightScale, -10);
        //mainCam.transform.position = new Vector3(transform.position.x + (gameRatio.x / 2 - .5f), transform.position.y + (gameRatio.y / 2 - .5f), -10);
        //mainCam.transform.position = new Vector3(transform.position.x * objWidthScale, transform.position.y * objHeightScale, -10);

        //freeform
        // cam 1.5>1.9 x, 3.5>1y (grid 6,10)
        // cam 1.5>7.6 x, 3.5 >6 y (grid 12,20)
        // cam 1.5> 4.55 x, 3.5>4 y (grid 8,16)


        //hd 1920,1080 (camWidth 17.7777777....)
        // cam 1.5>2.95 x, 3.5>1y (grid 6,10)
        // cam 1.5>11.8 x, 3.5 >6 y (grid 12,20)
        // cam 1.5>7.1 x, 3.5>4 y (grid 8,16)

        //1,2 (camWidth 5)
        // cam 1.5>0.83 x, 3.5>1y (grid 6,10)
        // cam 1.5>3.35 x, 3.5 >6 y (grid 12,20)
        // cam 1.5>2 x, 3.5>4 y (grid 8,16)

        float camX = (float)camWidth/2 + 0.5f;
        Debug.Log(camX);

        float camY = (gameRatio.y/2) - 4;
        //Debug.Log(camY);

        mainCam.transform.position = new Vector3(camX, camY, -10);

    }

    private void calGameRatio()
    {
        gameRatio.x = gridManager.getGridWidth();
        gameRatio.y = gridManager.getGridHeight();

        //Debug.Log("calgameRatio " + gameRatio);

    }

    private void calScreenRatio()
    {
        screenRatio.x = Screen.width;
        screenRatio.y = Screen.height;

    }
}
