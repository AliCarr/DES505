using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour
{ 
    public Button fastForwardButton;
    public Sprite play;
    public Sprite fastForward;
    public GameObject vignette;
    public GameObject pauseMenu;
    public Animator dialogueBox;

    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") && !dialogueBox.GetBool("IsOpen"))
        {
            Pause();
        }
    }

    public void GoToLevel()
    {
       SceneManager.LoadScene("Prototype");
        Time.timeScale = 1;

    }
    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            vignette.SetActive(true);
            pauseMenu.SetActive(true);
            pauseMenu.transform.GetChild(0).gameObject.SetActive(true);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            vignette.SetActive(false);
            pauseMenu.SetActive(false);
            isPaused = false;
        }

    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void FastForward()
    {
        if (Time.timeScale == 1.0f)
        {
            Time.timeScale = 2;
            fastForwardButton.image.sprite = fastForward;
        }
        else
        {
            Time.timeScale = 1;
            fastForwardButton.image.sprite = play;
        }
    }
}
