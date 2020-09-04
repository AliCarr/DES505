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
        UIManager.Instance.EnableGameMenu();
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
        {
            stateController.PushState(new PauseState(stateController));
        }

        if (UIManager.Instance.GetIsMainMenuPressed())
        {
            UIManager.Instance.SetIsMainMenuPressed(false);
            stateController.PopState(this);
            GameState topState = stateController.ReturnTopState();
            SceneManager.LoadScene("MenuScene");
            topState.OnStateEnter();
        }

        if(UIManager.Instance.TemperaturScript().GetGameOver())
        {
            UIManager.Instance.GetGameOverImage().SetActive(true);
            UIManager.Instance.GetRoundManager().SetRound(0);
            stateController.PushState(new PauseState(stateController));
        }
    }


}
