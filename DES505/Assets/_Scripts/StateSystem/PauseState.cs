using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameState
{
    StateController stateController;

    public PauseState(StateController stateController)
    {
        this.stateController = stateController;
    }

    public override void OnStateEnter()
    {
        UIManager.Instance.Pause();
    }

    public override void OnStateExit()
    {
        UIManager.Instance.Pause();
    }

    public override void OnStateUpdate()
    {
        if(Input.GetKeyDown("escape") )
        {
            stateController.PopState(this);
        }
    }
}
