using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressArea : MonoBehaviour
{
    private bool inBoundary;

    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int currentIndex = 0;
    private int randomIndex;


    SpriteRenderer sr;
    public GameObject TitlePoint;

    public int ID;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = true;
            PlayerMovement.instance.inBoundary = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = false;
            PlayerMovement.instance.inBoundary = false;
            VFXExit();
        }
    }

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (inBoundary)
        {
            if (PlayerMovement.instance.isPress)
            {
                Debug.Log("isPressed");
                PressFunctions();
                inBoundary = false;
            }
        }
    }

    private void PressFunctions()
    {
        SoundEffect();
        VFX();
    }


    private void SoundEffect()
    {
        //audio
        randomIndex = (int)Random.Range(0f, audioClips.Length);
        if (randomIndex == currentIndex)
        {
            randomIndex = (randomIndex + 1) % audioClips.Length;
        }
        currentIndex = randomIndex;

        audioSource.PlayOneShot(audioClips[currentIndex]);
        //Debug.Log("Playing " + audioClips[currentIndex].name);
    }

    private void VFX()
    {
        //alpha
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);

        TitlePoint.SetActive(true);

    }

    private void VFXExit()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        TitlePoint.SetActive(false);
    }
}
