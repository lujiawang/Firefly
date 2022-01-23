using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    Vector2 movement;

    private float holdTimeCounter;
    public float HoldTime = 1f;
    private float pressTime = 0.05f;

    public bool isHold = false;
    public bool isPress = false;

    public bool inBoundary = false;

    public static PlayerMovement instance;
    public bool inMenu = false;


    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int currentIndex = 0;
    private int randomIndex;
    private bool isPlaying = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    //input
    private void Update()
    {
        if (!inMenu)
        {
            movement.x = Input.GetAxisRaw("Horizontal"); //-1 ~ 1
            movement.y = Input.GetAxisRaw("Vertical");



            if (Input.GetKeyDown(KeyCode.Space))
            {
                holdTimeCounter = 0f;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                isPress = true;
                holdTimeCounter += Time.deltaTime;
                if (holdTimeCounter >= HoldTime)
                {
                    isHold = true;
                    holdTimeCounter = 0;
                    return;
                }

                if (holdTimeCounter >= pressTime && !inBoundary && !isPlaying)
                {
                    PlayNotes();
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                holdTimeCounter = 0f;
                isPress = false;
                isHold = false;

                isPlaying = false;
            }

        }

    }



    //movement
    private void FixedUpdate()
    {
        if (!inMenu)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }


    private void PlayNotes()
    {
        randomIndex = (int)Random.Range(0f, audioClips.Length);
        if (randomIndex == currentIndex)
        {
            randomIndex = (randomIndex + 1) % audioClips.Length;
        }
        currentIndex = randomIndex;

        audioSource.PlayOneShot(audioClips[currentIndex]);
        //Debug.Log("Playing " + audioClips[currentIndex].name);
        isPlaying = true;
    }



    public void ToMenu()
    {
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
        inMenu = true;
    }
}
