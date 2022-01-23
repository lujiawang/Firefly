using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WASD : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    Vector2 movement;

    public int Count = 0;
    private ObjectNext objectNext;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();

        objectNext = gameObject.GetComponent<ObjectNext>();
    }

    //input
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //-1 ~ 1
        movement.y = Input.GetAxisRaw("Vertical");

        if (Count == 4)
        {
            objectNext.finished = true;
        }
    }



    //movement
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }



}
