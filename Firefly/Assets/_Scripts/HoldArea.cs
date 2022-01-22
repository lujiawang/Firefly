using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldArea : MonoBehaviour
{
    private bool inBoundary;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = true;
            Debug.Log("in hold boundary");
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
            if (PlayerMovement.instance.isHold)
            {
                Debug.Log("isHold");
                inBoundary = false;
            }
        }
    }
}
