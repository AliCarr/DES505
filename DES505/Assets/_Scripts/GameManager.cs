using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool isInit = false;
    private StateController stateController;

    // Start is called before the first frame update
    void Awake()
    {
        isInit = true;
        DontDestroyOnLoad(gameObject);

        UIManager.Instance.Init();

        //Create a new State Machine
        stateController = new StateController();
        stateController.PushState(new MainMenuState(stateController));
    }

    // Update is called once per frame
    void Update()
    {
        stateController.UpdateStates();
    }
}
