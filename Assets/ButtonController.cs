using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject Setting_Menu;
    public GameObject Main_Menu;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayWithAI()
    {

    }

    public void CreateGroup()
    {


    }

    public void JoinGroup()
    {

    }

    public void OpenSettings()
    {
        Main_Menu.SetActive(false);
        Setting_Menu.SetActive(true);
    }



    public void Exit()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        Setting_Menu.SetActive(false);
        Main_Menu.SetActive(true);
    }

    public void GraphicsSettings()
    {

    }

    public void AudioSettings()
    {

    }

    public void UISettings()
    {
        // Open UI settings menu

    }
}
