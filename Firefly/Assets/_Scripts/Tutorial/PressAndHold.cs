using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAndHold : MonoBehaviour
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

    public static PressAndHold instance;


    private bool isPlaying = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    //input
    private void Update()
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
                TutorialAudio.instance.PlayNotes();
                isPlaying = true;
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



    //movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


}
