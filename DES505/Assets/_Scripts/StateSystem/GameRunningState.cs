using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRunningState : GameState
{
    StateController stateController;
    private Animator dialogueBox;
    private bool initGridControl = true;
    public GameRunningState(StateController stateController)
    {
        this.stateController = stateController;
    }

    public override void OnStateEnter()
    {
        initGridControl = true;
        Time.timeScale = 1;
        UIManager.Instance.EnableGameMenu();
        UIManager.Instance.GetWinImage().SetActive(false);
    }

    public override void OnStateExit()
    {
        UIManager.Instance.DisableGameMenu();
    }

    public override void OnStateUpdate()
    {
        if (initGridControl)
        {
            GridControls.Instance.Init();
            initGridControl = false;
        }
        
        dialogueBox = UIManager.Instance.dialogueBox;
        if (Input.GetKeyDown("escape") && !dialogueBox.GetBool("IsOpen"))
            stateController.PushState(new PauseState(stateController));

        if (UIManager.Instance.GetWinImage().activeSelf)
        {
            UIManager.Instance.GetRoundManager().SetRound(0);
            stateController.PushState(new PauseState(stateController));
        }

        if(UIManager.Instance.TemperaturScript().GetGameOver())
        {
            UIManager.Instance.GetGameOverImage().SetActive(true);
            UIManager.Instance.GetRoundManager().SetRound(0);
            stateController.PushState(new PauseState(stateController));
        }
    }


}
