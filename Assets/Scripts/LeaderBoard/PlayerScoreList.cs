using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerScoreList : MonoBehaviour
{



    public GameObject playerScoreEntryPrefab;

    [SerializeField] ScoreManager scoreManager;




    private void Start()
    {
        UpdateLeaderboardSortedByLevel();
    }



    public void UpdateLeaderboardSortedByLevel()
    {
        if (scoreManager == null)
        {
            Debug.LogWarning("No score manager component found");
            return;
        }

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);

            Destroy(c.gameObject);
        }

        var entiesSortedByLevel = scoreManager.GetSortedScoresByLevel();

        foreach (ScoreEntry entry in entiesSortedByLevel)
        {
            GameObject go = Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = entry.name;
            go.transform.Find("Level").GetComponent<TextMeshProUGUI>().text = entry.level.ToString();
        }
    }

    public void UpdateScores()
    {
        if (scoreManager == null)
        {
            Debug.LogWarning("No score manager component found");
            return;
        }

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);

            Destroy(c.gameObject);
        }

        var enties = scoreManager.GetScores();

        foreach (ScoreEntry entry in enties)
        {
            GameObject go = Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(this.transform);
            go.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = entry.name;
            go.transform.Find("Level").GetComponent<TextMeshProUGUI>().text = entry.level.ToString();
        }

    }
}


