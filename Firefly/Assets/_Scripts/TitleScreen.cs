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

    private AudioSource audioSource;
    public AudioClip[] audioClips;
    private int currentIndex = 0;
    private int randomIndex;
    private bool isPlaying = false;


    // Start is called before the first frame update
    void Start()
    {
        Credit.SetActive(false);
        audioSource = this.gameObject.GetComponent<AudioSource>();
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
                if (!isPlaying)
                    PlayNotes();
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                //credit
                Credit.SetActive(true);
                inCredit = true;
                buttonPress = true;
                if (!isPlaying)
                    PlayNotes();
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //quit
                QuitGame();
                buttonPress = true;
                if (!isPlaying)
                    PlayNotes();
            }
        }

        if (Input.GetKeyUp(KeyCode.A) )
        {
            buttonPress = false; 
            isPlaying = false;
        }

        if (inCredit && !buttonPress && Input.GetKeyDown(KeyCode.A))
        {
            Credit.SetActive(false);
            inCredit = false;
            if (!isPlaying)
                PlayNotes();
        }
    }


    private void StartGame()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(SceneLoad());
    }

    IEnumerator SceneLoad ()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneName);
    }

    private void QuitGame()
    {
        Application.Quit();
    }


    private void PlayNotes()
    {
        randomIndex = (int)Random.Range(0f, audioClips.Length);
        if (randomIndex == currentIndex)
        {
            randomIndex = (randomIndex + 1) % audioClips.Length;
        }
        currentIndex = randomIndex;

        audioSource.PlayOneShot(audioClips[currentIndex]);
        //Debug.Log("Playing " + audioClips[currentIndex].name);
        isPlaying = true;
    }

}
