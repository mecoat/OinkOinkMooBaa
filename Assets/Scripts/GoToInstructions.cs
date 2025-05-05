using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToInstructions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            loadInstructions();
        }
    }



    private void loadInstructions()
    {
        //load the instructions scene
        SceneManager.LoadScene("InstructionsScene");
    }
}
