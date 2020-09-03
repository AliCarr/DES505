using UnityEngine;
using UnityEngine.SceneManagement;

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
        UIManager.Instance.UnPause();
        UIManager.Instance.SetIsResumed(false);
        UIManager.Instance.SetIsMainMenuPressed(false);
    }

    public override void OnStateUpdate()
    {
        if (Input.GetKeyDown("escape") || UIManager.Instance.GetIsResumed())
        {
            stateController.PopState(this);
        }

        if (UIManager.Instance.GetIsMainMenuPressed())
        {
            stateController.PopState(this);
            GameState topState = stateController.ReturnTopState();
            stateController.PopState(topState);
            GameState topState2 = stateController.ReturnTopState();
            SceneManager.LoadScene("MenuScene");
            topState2.OnStateEnter();
        }
    }

}
