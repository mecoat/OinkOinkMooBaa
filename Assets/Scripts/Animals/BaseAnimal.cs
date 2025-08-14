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

    [SerializeField]
    private AudioClip goodCollideSound;

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
        if (!isMoving)
        {
            rb.velocity = Vector2.zero;
            if (transform.position != homeTile.transform.position)
            {
                transform.position = homeTile.transform.position;
                Debug.Log("moving home");
            }
        }
    }

    // According to https://docs.unity3d.com/2022.3/Documentation/Manual/CrossPlatformConsiderations.html should work on mobile too
    private void OnMouseDown()
    {
        isMoving = true;

        sound.clip = animalSound;
        sound.loop = true;
        sound.Play();

        offset = GetMousePos() - (Vector2)transform.position;

        rb.constraints = RigidbodyConstraints2D.None;
    }

    private void OnMouseUp()
    {
        stopMoving();
    }

    private void OnMouseDrag()
    {
        if (isMoving)
        {
            rb.MovePosition(GetMousePos() - offset);
        }
        
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        stopMoving();

        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Animal")
        {
            Debug.Log("hit animal");
            Debug.Log("hit " + collision.gameObject.name);
            Debug.Log("hit " + collision.gameObject.transform.position);
            Debug.Log("home @ " + collision.gameObject.transform.localPosition);

            sound.PlayOneShot(badCollideSound);

        } 
        else if (collision.gameObject.tag == "Pen")
        {

            var penColliided = collision.gameObject.GetComponent<BasePen>();
            //Debug.Log("hit Pen");

            //Debug.Log(penColliided.targetAnimal);
            //Debug.Log(this.gameObject);

            if (penColliided.targetAnimal.name == this.gameObject.name)
            {
                Debug.Log("match");
                bool checkMatch = penColliided.CheckMatch();

                if (!checkMatch)
                {
                    Debug.Log("play bad");
                    sound.PlayOneShot(badCollideSound);
                } 
                else
                {
                    Debug.Log("play good");
                    //AudioSource.PlayClipAtPoint(goodCollideSound, (Vector2)transform.position);
                    AudioSource.PlayClipAtPoint(goodCollideSound, Camera.main.transform.position, 1f);
                    //sound.PlayOneShot(goodCollideSound);
                    gameObject.SetActive(false);
                }
            }
            else
            {
                sound.PlayOneShot(badCollideSound);

            }

            Debug.Log(penColliided.noAnimals);
        }


    }

    private void stopMoving()
    {
        sound.Stop();

        transform.position = homeTile.transform.position;

        isMoving = false;

        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

}
