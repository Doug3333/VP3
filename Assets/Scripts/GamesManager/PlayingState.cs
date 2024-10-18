using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingState : State
{
    [SerializeField] Player myPlayer;
    [SerializeField] EnemyManager myEnemyManager;

    [SerializeField] PlayerScoreList myScoreList;

    //[SerializeField] GameObject PlayingUI;

    //public override void EnterState()
    //{
    //    PlayingUI.SetActive(true);
    //}

    //public override void ExitState()
    //{
    //    PlayingUI.SetActive(false);
    //}



    public override void UpdateState()
    {        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PauseState>();
            myScoreList.UpdateScores();
        }
        base.UpdateState();

        myPlayer.UpdatePlayer();
        myEnemyManager.UpdateEnemyManager();


        
    }

    
}
