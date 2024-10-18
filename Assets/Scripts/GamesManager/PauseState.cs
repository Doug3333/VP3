using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PauseState : State
{
    [SerializeField] Player player;

     //[SerializeField] PlayerScoreList myScoreList;
    public override void UpdateState()
    {
        base.UpdateState();
        player.SetVelToCero();

       // myScoreList.UpdateScores();


        EnemyManager.Instance.OnStateChange();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamesManager.Instance.SwitchState<PlayingState>();

        }
    }


    
}
