using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainMenu;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public List<State> states = new List<State>();
    public State CurrentState = null;

    public void SwitchState<aState>()
    {

        foreach (State s in states)
        {
            if (s.GetType() == typeof(aState))
            {
                CurrentState?.ExitState();
                CurrentState = s;
                CurrentState.EnterState();
                return;
            }
        }
        Debug.LogWarning("States does not exist");
    }

    public virtual void UpdateStateMachine()
    {
        CurrentState?.UpdateState();
        //Is this Correct Daniel?
    }

    public bool IsState<aState>()
    {
        if (!CurrentState) return false;
        return CurrentState.GetType() == typeof(aState);
    }
    public enum MainMenuState
    {
        MainMenu = 0,
        Options = 1,
        LevelSelect = 2
    }

    public MainMenuState State;

    public GameObject MainMenuUI;
    public GameObject OptionsUI;
    public GameObject LevelSelectUI;

    private void Update()
    {

        switch (State)
        {

            case MainMenuState.MainMenu:
                //MainMenuUpdate();
                break;
            case MainMenuState.Options:
                //OptionsUpdate();
                break;
            case MainMenuState.LevelSelect:
                //LevelSelectUpdate();
                break;

        }

        //State = aState;
        // Daniel Help...?
    }



    public void SwitchState(int aState)
    {
        SwitchState((MainMenuState)aState);
    }

    public void SwitchState(MainMenuState aState)
    {
        MainMenuUI.SetActive(aState == MainMenuState.MainMenu);
        OptionsUI.SetActive(aState == MainMenuState.Options);
        LevelSelectUI.SetActive(aState == MainMenuState.LevelSelect);

        State = aState;
    }

}


