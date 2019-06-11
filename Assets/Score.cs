using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public GameObject player;
    public int score = 0;
    int turets;
    public Text ScoreText;
    public InputField nameField;
    public string Name;

    private void Start()
    {
        turets = GameObject.FindGameObjectsWithTag("Turet").Length;
    }

    void Update () {

        score = (player.GetComponent<Stats>().HP * 2 + (int)player.GetComponent<Stats>().Fuel) * (turets - GameObject.FindGameObjectsWithTag("Turet").Length);
        ScoreText.text = score.ToString();
    }

   public void GetName()
    {
        Name = nameField.text;
    }

    public void SaveScore()
    {
        GetName();
        ScoreSaver.SaveScore(this);
    }
}
