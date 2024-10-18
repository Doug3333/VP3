using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortButton : MonoBehaviour
{
    [SerializeField] PlayerScoreList my_playerScoreList;

    public void OnClickSortLevel()
    {
        my_playerScoreList.UpdateLeaderboardSortedByLevel();
    }
}
