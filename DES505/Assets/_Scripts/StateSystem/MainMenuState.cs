using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuState : GameState
{
    StateController stateController;


    public MainMenuState(StateController stateController)
    {
        this.stateController = stateController;
    }

    public override void OnStateEnter()
    {
        UIManager.Instance.EnableMainMenu();
    }

    public override void OnStateExit()
    {
        //UIManager.Instance.DisableMainMenu();
    }

    public override void OnStateUpdate()
    {
        UIManager.Instance.PlayButton().onClick.AddListener(OnClick);  
    }

    private void OnClick()
    {
        stateController.PushState(new GameRunningState(stateController));
        SceneManager.LoadScene("Prototype");
        Time.timeScale = 1;
        UIManager.Instance.DisableMainMenu();
    }
}
