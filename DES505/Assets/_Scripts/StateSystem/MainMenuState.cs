﻿using UnityEngine;
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
        UIManager.Instance.DisableMainMenu();
    }

    public override void OnStateUpdate()
    {     
        if(UIManager.Instance.GetIsPlayPressed())
        {
            OnClick();
        }

        if (UIManager.Instance.TemperaturScript().GetGameOver())
        {
            UIManager.Instance.TemperaturScript().ResetTemperature();
            UIManager.Instance.GetGameOverImage().SetActive(false);
        }
    }

    private void OnClick()
    {
        stateController.PushState(new GameRunningState(stateController));
        SceneManager.LoadScene("Prototype");
        UIManager.Instance.DisableMainMenu();
        UIManager.Instance.SetIsPlayPressed(false);


    }
}
