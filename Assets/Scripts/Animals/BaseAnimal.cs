using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimal : MonoBehaviour
{
    public Tile homeTile;

    [SerializeField]
    private AudioClip animalSound;

    //holder for the desired Audiosource on the object
    private AudioSource sound;

    //private bool isMoving;

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
        //isMoving = true;

        sound.clip = animalSound;
        sound.loop = true;
        sound.Play();
    }

    private void OnMouseUp()
    {
        sound.Stop();

        transform.position = homeTile.transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
