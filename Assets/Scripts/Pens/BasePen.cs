using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePen : MonoBehaviour
{
    public int noAnimals;
    
    [SerializeField]
    private AudioClip animalSound;

    //holder for the desired Audiosource on the object
    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }


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
        StartCoroutine(CoPlayDelayedClip(noAnimals));
    }

    IEnumerator CoPlayDelayedClip(int noPlays)
    {
        float delayTime = animalSound.length;
        Debug.Log(noPlays);

        for (var i = 0; i < noPlays; i++)
        {

            sound.PlayOneShot(animalSound);
            yield return new WaitForSeconds(delayTime);

        }
    }
}
