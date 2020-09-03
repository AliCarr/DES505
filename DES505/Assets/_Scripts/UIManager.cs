using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Button playButton;

    [Header("Menus")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameMenuUI;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private Button fastForwardButton;
    [SerializeField] private Sprite play;
    [SerializeField] private Sprite fastForward;
    [SerializeField] private GameObject vignette;
    [SerializeField] public Animator dialogueBox;
    [SerializeField] private Canvas canvas;

    private bool isPaused = false;
    public void Init()  { }

    public Button PlayButton()  { return playButton;  } 
    public bool ResumePressed()  { return true;  }
    public bool MainMenuPressed()  { return true;  }

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

    public void DisableMainMenu()
    {
        mainMenu.SetActive(false);
    }   
    
    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
    }    
    
    public void DisableGameMenu()
    {
        gameMenuUI.SetActive(false);
    }   
    
    public void EnableGameMenu()
    {
        gameMenuUI.SetActive(true);
    }
}
