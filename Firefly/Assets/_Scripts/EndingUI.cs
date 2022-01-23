using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class EndingUI : MonoBehaviour
{
    public static EndingUI instance;
    public int finishedNum = 0;
    public int totalNum = 12;

    public string EndingScene;

    public PlayableDirector PD;


    private void Awake()
    {
        instance = this;
        
    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (finishedNum == totalNum)
        {
            StartCoroutine(TimelineStart());
            this.enabled = false;
        }
    }
    IEnumerator TimelineStart()
    {
        yield return new WaitForSeconds(1f);
        PD.gameObject.SetActive(true);
        PD.Play();
        StartCoroutine(Ending());
    }


    IEnumerator Ending()
    {
        yield return new WaitForSeconds(2f + (float)PD.duration);
        SceneManager.LoadScene(EndingScene);
    }

}
