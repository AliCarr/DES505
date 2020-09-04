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
    }

    public override void OnStateUpdate()
    {
        if (Input.GetKeyDown("escape") || UIManager.Instance.GetIsResumed())
        {
            stateController.PopState(this);
            UIManager.Instance.SetIsResumed(false);
        }

        if (UIManager.Instance.GetIsMainMenuPressed())
        {
            stateController.PopState(this);
            GameState topState = stateController.ReturnTopState();
            UIManager.Instance.SetIsMainMenuPressed(false);
            stateController.PopState(topState);
            GameState topState2 = stateController.ReturnTopState();
            SceneManager.LoadScene("MenuScene");
            topState2.OnStateEnter();
        }

        if(UIManager.Instance.GetIsRestarted())
        {
            stateController.PopState(this);
            UIManager.Instance.SetIsRestarted(false);
            UIManager.Instance.ClearAllBuildings();
            GameState topState = stateController.ReturnTopState();
            SceneManager.LoadScene("Prototype");
            topState.OnStateEnter();
        }
    }

}
