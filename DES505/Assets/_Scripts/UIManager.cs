using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("Menus")]
    [SerializeField] private GameObject mainMenu = null;
    [SerializeField] private GameObject gameMenuUI = null;
    [SerializeField] private GameObject pauseMenu = null;

    [SerializeField] private Button fastForwardButton = null;
    [SerializeField] private Sprite play = null;
    [SerializeField] private Sprite fastForward = null;
    [SerializeField] private GameObject vignette = null;
    [SerializeField] private TemperatureScript temperatureScript = null;
    [SerializeField] private SPScripts spScript = null;
    [SerializeField] private RoundManager roundManager = null;
    [SerializeField] private GameObject winImage = null;

    [SerializeField] public Animator dialogueBox = null;

    //private bool isPaused = false;
    private bool isMainMenuPressed = false;
    private bool isResumed = false;
    private bool isPlayPressed = false;
    private bool isRestarted = false;

    public void Init() { DontDestroyOnLoad(gameObject); }

    public bool GetIsPlayPressed() { return isPlayPressed; }
    public void SetIsPlayPressed(bool value) { isPlayPressed = value; }
    public bool GetIsMainMenuPressed() { return isMainMenuPressed; }
    public void SetIsMainMenuPressed(bool value) { isMainMenuPressed = value; }
    public bool GetIsResumed() { return isResumed; }
    public void SetIsResumed(bool value) { isResumed = value; }    
    public bool GetIsRestarted() { return isRestarted; }
    public void SetIsRestarted(bool value) { isRestarted = value; }

    public TemperatureScript TemperaturScript()  { return temperatureScript;  }  
    public SPScripts SPScript()  { return spScript;  }   
    public RoundManager GetRoundManager()  { return roundManager;  } 
    public GameObject GetWinImage()  { return winImage;  } 


    public void Pause()
    {
        Time.timeScale = 0;
        vignette.SetActive(true);
        pauseMenu.SetActive(true);
        pauseMenu.transform.GetChild(0).gameObject.SetActive(true);
    }  
    
    public void UnPause()
    {
        Time.timeScale = 1;
        vignette.SetActive(false);
        pauseMenu.SetActive(false);
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

    public void ClearAllBuildings()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");

        foreach (GameObject building in buildings)
        {
            if (building.name.EndsWith("Clone"))
            {
                Destroy(building);
            }
        }
    }
}
