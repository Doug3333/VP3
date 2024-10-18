using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamesManager : StateMachine 
{
    public static GamesManager Instance;
    public Player player;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SwitchState<PauseState>();
    }


    private void Update()
    {
        UpdateStateMachine();

    }

    /*
    private void Update()
    {
        switch (state)
        {
            case GameState.Playing:

               
             player.PlayerUpdate();

                break;
            case GameState.Paused:

        }
    }


    */
}
