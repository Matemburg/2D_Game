using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour {
    public Canvas endGame;
    public Text endText;
    public GameObject player;
    private void Start()
    {
        if ((!endGame.enabled))
        {
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        if ((!endGame.enabled) && player.GetComponent<Stats>().HP <= 0)
        {
            Cursor.visible = true;
            endGame.enabled = true;
            endText.text = "Game Over";
        }
        else if ((!endGame.enabled) && GameObject.FindGameObjectsWithTag("Turet").Length <= 0)
        {
            endGame.enabled = true;
            Cursor.visible = true;

        }
        else if  ((!endGame.enabled) && player.GetComponent<Stats>().Fuel <= 0)
            {
                Cursor.visible = true;
                endGame.enabled = true;
                endText.text = "Game Over";
            }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }

    }

    public void Restart()
    {
        //Application.LoadLevel(1);
        SceneManager.LoadScene(1);
    }

    public void EndGameButton()
    {
        SceneManager.LoadScene(0);
    }
}
