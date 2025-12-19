using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameButtons : MonoBehaviour
{
    public GameObject PlayerUi;
    public GameObject MenuInGame;
 

    public void MenuInGamebutton()
    {
        Time.timeScale = 0f;
        MenuInGame.SetActive(true);
        PlayerUi.SetActive(false);
    }

    public void ReSume()
    {
        Time.timeScale = 1f;
        MenuInGame.SetActive(false);
        PlayerUi.SetActive(true);
    }

    public void MainMenu()
    {
        Time.timeScale =1f;
        SceneManager.LoadScene("MainMenu");
    }
}
