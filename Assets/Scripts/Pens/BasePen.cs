using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    // According to https://docs.unity3d.com/2022.3/Documentation/Manual/CrossPlatformConsiderations.html should work on mobile too
    private void OnMouseDown()
    {
        Debug.Log("hit me" );
    }
}
