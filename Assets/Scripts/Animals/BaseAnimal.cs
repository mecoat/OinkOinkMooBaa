using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAnimal : MonoBehaviour
{
    public Tile homeTile;

    [SerializeField]
    private AudioClip animalSound;

    [SerializeField]
    private AudioClip badCollideSound;

    //holder for the desired Audiosource on the object
    private AudioSource sound;

    private bool isMoving = false;

    private Rigidbody2D rb;

    private Vector2 offset;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
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
        isMoving = true;

        sound.clip = animalSound;
        sound.loop = true;
        sound.Play();

        offset = GetMousePos() - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        sound.Stop();

        transform.position = homeTile.transform.position;

        isMoving = false;
    }

    private void OnMouseDrag()
    {
        rb.MovePosition (GetMousePos() - offset);
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        Debug.Log(collision.gameObject.tag);
    }
}
