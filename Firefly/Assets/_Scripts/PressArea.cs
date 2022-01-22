using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressArea : MonoBehaviour
{
    private bool inBoundary;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = true;
            Debug.Log("in press boundary");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = false;
        }
    }

    private void Update()
    {
        if (inBoundary)
        {
            if (PlayerMovement.instance.isPress)
            {
                Debug.Log("isPressed");
                inBoundary = false;
            }
        }
    }
}
