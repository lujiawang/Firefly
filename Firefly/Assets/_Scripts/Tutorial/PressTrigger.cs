using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PressTrigger : MonoBehaviour
{
    private bool inBoundary;

    SpriteRenderer sr;
    private PlayableDirector pd;
    private GameObject TitlePoint;

    public bool pressed;

    private GameObject DottedCircle;

    private ObjectNext objectNext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = true;
            PressAndHold.instance.inBoundary = true;


           //sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inBoundary = false;
            PressAndHold.instance.inBoundary = false;
            VFXExit();

        }
    }

    private void Start()
    {

        TitlePoint = this.transform.Find("TitlePoint").gameObject;
        DottedCircle = this.transform.Find("DottedCircle").gameObject;


        sr = this.gameObject.GetComponent<SpriteRenderer>();
        if (TitlePoint)
        {
            pd = TitlePoint.GetComponentInChildren<PlayableDirector>();
            TitlePoint.SetActive(false);
        }


        objectNext = this.transform.parent.gameObject.GetComponent<ObjectNext>();
    }

    private void Update()
    {
        if (inBoundary)
        {
            if (PressAndHold.instance.isPress)
            {
                Debug.Log("isPressed");
                PressFunctions();
                inBoundary = false;
            }
        }
    }

    private void PressFunctions()
    {
        pressed = true;
        TutorialAudio.instance.PlayNotes();
        VFX();
    }

    private void VFX()
    {
        //alpha
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.2f);

        if (TitlePoint)
        {
            TitlePoint.SetActive(true);
            pd.Play();
            //Destroy(TitlePoint, (float)pd.duration);

            DottedCircle.SetActive(false);

            StartCoroutine(ToNextObject());

        }
    }


    IEnumerator ToNextObject()
    {
        yield return new WaitForSeconds((float)pd.duration);
        objectNext.finished = true;
    }


    private void VFXExit()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        /*if (TitlePoint)
        {
            TitlePoint.SetActive(false);
        }*/
    }
}
