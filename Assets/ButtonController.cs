using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SilentClash
{


    public class ButtonController : MonoBehaviour
    {
        public GameObject Setting_Menu;
        public GameObject Main_Menu;
        public GameObject HostLobby;
        public GameObject JoinLobby;
        public GameObject inputPanel;

      

        public void PlayWithAI()
        {

        }

        public void CreateGroup()
        {
            Main_Menu.SetActive(false);
            HostLobby.SetActive(true);
            NetworkManager.Instance.StartHost();


        }

        public void JoinGroup()
        {
            Main_Menu.SetActive(false);
            inputPanel.SetActive(true);
            NetworkManager.Instance.ConnectToServer("127.0.0.1", "7777", "Player2");
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

            if (gameObject.transform.parent.gameObject.tag == "HostLobby")
            {
                HostLobby.SetActive(false);
                Main_Menu.SetActive(true);
            }
            else if (gameObject.transform.parent.gameObject.tag == "JoinLobby")
            {
                JoinLobby.SetActive(false);
                Main_Menu.SetActive(true);
            }
            else if (gameObject.transform.parent.gameObject.tag == "inputPanel")
            {
                inputPanel.SetActive(false);
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
}