using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    public static EndingUI instance;
    public int finishedNum = 0;
    private int totalNum = 2;

    public string EndingScene;

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
            StartCoroutine(Ending());
            this.enabled = false;
        }
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(EndingScene);
    }
}
