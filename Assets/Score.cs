using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public GameObject Stats;
    public int score = 0;
   // int turets;
    public Text ScoreText;
    public InputField nameField;
    public string Name;

    private void Start()
    {
        //turets = GameObject.FindGameObjectsWithTag("Turet").Length;
    }

    void Update()
    {

        score = (Stats.GetComponent<Stats>().HP * 2 + (int)Stats.GetComponent<Stats>().Fuel) + 250 * Stats.GetComponent<Stats>().turretdestroyed;
        ScoreText.text = score.ToString();
    }

    public void GetName()
    {
        Name = nameField.text;
    }

    public void SaveScore()
    {
        GetName();
        AddHighscoreEntry(score, Name);
    }

    private void AddHighscoreEntry(int score, string name)
    {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            // There's no stored table, initialize
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;


    }
}