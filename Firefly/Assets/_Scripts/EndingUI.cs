using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingUI : MonoBehaviour
{
    public static EndingUI instance;
    public int finishedNum = 0;
    private int totalNum = 12;

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
            Ending();
            this.enabled = false;
        }
    }

    void Ending()
    {
        SceneManager.LoadScene(EndingScene);
    }
}
