using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCanvas : MonoBehaviour {
    public Canvas endGame;
    public Text endText;
    public GameObject player;
    public LevelSystem levelSystem;
    private void Start()
    {
        if ((!endGame.enabled))
        {
            Cursor.visible = false;
        }
    }

    void LateUpdate()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Turet").Length.ToString());
        if ((!endGame.enabled) && player.GetComponent<Stats>().HP <= 0)
        {
            Cursor.visible = true;
            endGame.enabled = true;
            endText.text = "Game Over";
        }
        else if ((!endGame.enabled) && GameObject.FindGameObjectsWithTag("Turet").Length <= 0)
        {
            levelSystem.NewLvl();
            if (RenderSettings.skybox.HasProperty("_Tint"))
                RenderSettings.skybox.SetColor("_Tint", Random.ColorHSV());
            else if (RenderSettings.skybox.HasProperty("_SkyTint"))
                RenderSettings.skybox.SetColor("_SkyTint", Random.ColorHSV());
            Debug.Log("NEXT");

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
