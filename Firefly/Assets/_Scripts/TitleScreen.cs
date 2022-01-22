using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private bool buttonPress = false;
    public string SceneName = "Level 1";
    public GameObject Credit;
    private bool inCredit = false;

    // Start is called before the first frame update
    void Start()
    {
        Credit.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!buttonPress && !inCredit)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttonPress = true;
                StartGame();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //credit
                Credit.SetActive(true);
                inCredit = true;
                buttonPress = true;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //quit
                QuitGame();
                buttonPress = true;
            }
        }

        if (inCredit && Input.GetKeyUp(KeyCode.A) )
        {
            buttonPress = false;
        }

        if (inCredit && !buttonPress && Input.GetKeyDown(KeyCode.A))
        {
            Credit.SetActive(false);
            inCredit = false;
        }
    }


    private void StartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneName);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
