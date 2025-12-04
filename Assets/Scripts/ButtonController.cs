using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using TMPro; 
namespace SilentClash

{


    public class ButtonController : MonoBehaviour
    {
        public GameObject Main_Menu;
        public GameObject Setting_Menu;
        public GameObject HostLobby;
        public GameObject JoinLobby;
        public GameObject inputPanel;
        public TMP_InputField usernameInput;
        public TMP_InputField ipAddressInput;




        public void PlayWithAI()
        {

        }

        public void CreateGroup()
        {
            Main_Menu.SetActive(false);
            HostLobby.SetActive(true);
            NetworkConnectionManager.Instance.StartHost();


        }

        public void OpenJoinPanel()
        {          
            Main_Menu.SetActive(false);
            inputPanel.SetActive(true);
        }

        public void JoinGroup()
        {
            string ip = ipAddressInput.text;
            PlayerInfo.LocalPlayerName = usernameInput.text;
            NetworkConnectionManager.Instance.StartClient(ip);
            Main_Menu.SetActive(false);
            inputPanel.SetActive(false);
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

            if (gameObject.transform.parent.gameObject.tag == "HostLobby")
            {
                HostLobby.SetActive(false);
                Main_Menu.SetActive(true);
                NetworkConnectionManager.Instance.StopHost();
            }
            else if (gameObject.transform.parent.gameObject.tag == "JoinLobby")
            {
                JoinLobby.SetActive(false);
                Main_Menu.SetActive(true);
                NetworkConnectionManager.Instance.StopHost();
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