using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public List<State> states = new List<State>();
    public State CurrentState = null;
    public Action<State> stateEvent;

    public void SwitchState<aState>()
    {

        foreach (State s in states)
        {
            if(s.GetType() == typeof(aState))
            {
                CurrentState?.ExitState();
                CurrentState = s;
                CurrentState.EnterState();
                stateEvent?.Invoke(CurrentState);
                return;

            }
            
        }

        Debug.LogWarning("State does not exist");
    }
    

    public virtual void UpdateStateMachine()
    {
        CurrentState?.UpdateState();
    }

    public bool IsState<aState>()
    {
        if (!CurrentState) return false;
        return CurrentState.GetType() == typeof(aState);
    }
}