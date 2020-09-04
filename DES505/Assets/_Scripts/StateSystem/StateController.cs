using System.Collections.Generic;
using UnityEngine;

//State Controller or State Machine doesnt need to inherit from Monobehaviour 
public class StateController
{
    public Stack<GameState> stateStack = new Stack<GameState>();

    public void PushState(GameState gameState)
    {
        Debug.Assert(stateStack.Count == 0 || stateStack.Peek() != gameState, "Trying to push an already active state");
        stateStack.Push(gameState);
        stateStack.Peek().OnStateEnter();
    }  
    
    public void PopState(GameState gameState)
    {
        Debug.Assert(stateStack.Count != 0 || stateStack.Peek() != gameState, "Trying to pop non active state");
        stateStack.Peek().OnStateExit();
        stateStack.Pop();
    }

    public GameState ReturnTopState()
    {
        return stateStack.Peek();
    }

    public void UpdateStates()
    {
        if (stateStack.Count > 0)
        {
            GameState gameState = stateStack.Peek();
            gameState.OnStateUpdate();
        }
    }
}
