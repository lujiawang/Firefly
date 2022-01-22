using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour
{
    public GameObject ObjectToEnable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ObjectToEnable.SetActive(true);
            Debug.Log(ObjectToEnable.name  + " enbled");
        }
    }
}
