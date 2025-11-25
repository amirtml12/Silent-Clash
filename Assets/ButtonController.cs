using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject Setting_Menu;
    public GameObject Main_Menu;
    public GameObject HostLobby;
    public GameObject JoinLobby;
    
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
        Main_Menu.SetActive(false);
        HostLobby.SetActive(true);


    }

    public void JoinGroup()
    {
        Main_Menu.SetActive(false);
        JoinLobby.SetActive(true);
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

        if (gameObject.transform.parent.gameObject.name == "HostLobby")
        {
            HostLobby.SetActive(false);
            Main_Menu.SetActive(true);
        }
        else if (gameObject.transform.parent.gameObject.name == "JoinLobby")
        {
            JoinLobby.SetActive(false);
            Main_Menu.SetActive(true);
        }

        else
        {
            Setting_Menu.SetActive(false);
            Main_Menu.SetActive(true);
        }

    
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
