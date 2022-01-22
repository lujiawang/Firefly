using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    Vector2 movement;

    private float holdTimeCounter;
    public float HoldTime = 1f;

    public bool isHold = false;
    public bool isPress = false;

    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
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
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            holdTimeCounter = 0f;
            isPress = false;
            isHold = false;
        }

    }

    //movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
