using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDsingle : MonoBehaviour
{
    private WASD wasd;
    private void Start()
    {
        wasd = this.transform.parent.gameObject.GetComponent<WASD>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wasd.Count++;
            TutorialAudio.instance.PlayNotes();
            this.gameObject.SetActive(false);
        }
    }
}
