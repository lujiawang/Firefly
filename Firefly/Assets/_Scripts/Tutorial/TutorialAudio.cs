using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialAudio : MonoBehaviour
{
    public static TutorialAudio instance;

    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int currentIndex = 0;
    private int randomIndex;
    private bool isPlaying = false;

    private void Awake()
    {
        instance = this;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }


    public void PlayNotes()
    {
        //if (!isPlaying)
        //{
            randomIndex = (int)Random.Range(0f, audioClips.Length);
            if (randomIndex == currentIndex)
            {
                randomIndex = (randomIndex + 1) % audioClips.Length;
            }
            currentIndex = randomIndex;

            audioSource.PlayOneShot(audioClips[currentIndex]);
            //Debug.Log("Playing " + audioClips[currentIndex].name);
            //isPlaying = true;
        //}
    }



}
