using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


[System.Serializable]
public class ScoreCointaner{

    public int score;
    public string Name;

    public ScoreCointaner(Score score)
    {
        this.score = score.score;
        this.Name = score.Name;
    }

    public ScoreCointaner (int score, string Name)
    {
        this.score = score;
        this.Name = Name;
    }
}
