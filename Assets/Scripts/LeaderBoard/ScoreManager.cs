using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ScoreManager : MonoBehaviour
{
    [SerializeField] ScoreSaverName reader;

    ScoreData scoreData;
    List<ScoreEntry> sortedScoreData;

    int clickToggleLevel = 0;
   

    void Init()
    {
        scoreData = reader.LoadData();
    }

    public ScoreEntry GetScore(string playerName)
    {
        Init();
        scoreData = reader.LoadData();
        ScoreEntry singleEntry = scoreData.scoreEntries.Find(x => x.name == playerName);

        return singleEntry;
    }

    public ScoreEntry[] GetScores()
    {
        Init();
        return scoreData.scoreEntries.ToArray();
    }

    public List<ScoreEntry> GetSortedScoresByLevel()
    {
        Init();

        switch (clickToggleLevel)
        {
            case 0:
                sortedScoreData = scoreData.scoreEntries.OrderBy(entry => entry.level).ToList();
                clickToggleLevel = 1;
                break;
            case 1:
                sortedScoreData = scoreData.scoreEntries.OrderByDescending(entry => entry.level).ToList();
                clickToggleLevel = 0;
                break;
            default:
                break;
        }

        return sortedScoreData;
    }
}


