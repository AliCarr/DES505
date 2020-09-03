using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunningState : GameState
{
    StateController stateController;
    private Animator dialogueBox;

    public GameRunningState(StateController stateController)
    {
        this.stateController = stateController;
    }

    public override void OnStateEnter()
    {
        UIManager.Instance.EnableGameMenu();
    }

    public override void OnStateExit()
    {
        UIManager.Instance.DisableGameMenu();
    }

    public override void OnStateUpdate()
    {
        GridControls.Instance.Init();
        dialogueBox = UIManager.Instance.dialogueBox;
        if (Input.GetKeyDown("escape") && !dialogueBox.GetBool("IsOpen"))
        {
            stateController.PushState(new PauseState(stateController));
        }


    }


}
