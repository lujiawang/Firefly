using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HoldArea : MonoBehaviour
{
    private bool inBoundary;

    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int currentIndex = 0;
    private int randomIndex;

    SpriteRenderer sr;

    public int ID = 0;
    public bool held;

    private PlayableDirector fragmentPD;

    private GameObject DottedCircle;
    private GameObject BigLightenOpen;
    private GameObject BigLightenClose;

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
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }
    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        fragmentPD = this.GetComponentInChildren<PlayableDirector>();

        DottedCircle = this.transform.Find("DottedCircle").gameObject;
        BigLightenOpen = this.transform.Find("BigLightenOpen").gameObject;
        BigLightenClose = this.transform.Find("BigLightenClose").gameObject;
    }


    private void Update()
    {
        if (inBoundary)
        {
            if (PlayerMovement.instance.isHold)
            {
                Debug.Log("isHold");
                HoldFunctions();
                inBoundary = false;
            }
        }
    }


    private void HoldFunctions()
    {
        held = true;
        SoundEffect();
        VFX();

        this.enabled = false;
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
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

        fragmentPD.Play();
        DottedCircle.SetActive(false);

        BigLightenOpen.SetActive(true);

        ParticleSystem bigLightPart = BigLightenOpen.gameObject.GetComponent<ParticleSystem>();
        float duration = bigLightPart.main.duration;
        StartCoroutine(LightClose(duration));
    }

    IEnumerator LightClose(float duration)
    {
        yield return new WaitForSeconds(duration + 0.5f);
        //BigLightenOpen.SetActive(false);
        BigLightenClose.SetActive(true);
    }
}
