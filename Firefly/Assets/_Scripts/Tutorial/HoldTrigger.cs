using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HoldTrigger : MonoBehaviour
{
    private bool inBoundary;

    SpriteRenderer sr;

    public bool held;

    private PlayableDirector fragmentPD;

    private GameObject DottedCircle;
    private GameObject BigLightenOpen;
    private GameObject BigLightenClose;

    private ObjectNext objectNext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = true;
            PressAndHold.instance.inBoundary = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = false;
            PressAndHold.instance.inBoundary = false;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        }
    }
    private void Start()
    {
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        fragmentPD = this.GetComponentInChildren<PlayableDirector>();

        DottedCircle = this.transform.Find("DottedCircle").gameObject;
        BigLightenOpen = this.transform.Find("BigLightenOpen").gameObject;
        BigLightenClose = this.transform.Find("BigLightenClose").gameObject;


        objectNext = this.transform.parent.gameObject.GetComponent<ObjectNext>();
    }


    private void Update()
    {
        if (inBoundary)
        {
            if (PressAndHold.instance.isHold)
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
        TutorialAudio.instance.PlayNotes();
        VFX();

        this.enabled = false;
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
        
        StartCoroutine(ToNextObject(duration));
    }
    IEnumerator ToNextObject(float duration)
    {
        yield return new WaitForSeconds(duration);
        objectNext.finished = true;
    }
}
