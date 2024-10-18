using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class ScoreEntry
{
    public string name;
    public int level;

    public ScoreEntry(string name, int level)
    {
        this.name = name;
        this.level = level;
    }

}

public class ScoreData
{
    public List<ScoreEntry> scoreEntries = new();


}

