using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using TMPro; 
namespace SilentClash

{


    public class ButtonController : MonoBehaviour
    {
        public static ButtonController Instance;
        public GameObject Main_Menu;
        public GameObject Setting_Menu;
        public GameObject HostLobby;
        public GameObject JoinLobby;
        public GameObject inputPanel;
        public TMP_InputField UserNameInput;
        public TMP_InputField ipInput;


        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }




        public void PlayWithAI()
        {

        }

        public void CreateGroup()
        {
            Main_Menu.SetActive(false);
            HostLobby.SetActive(true);
            NetworkConnectionManager.Instance.StartHost();


        }

        public void StartGame()
        {
            NetworkConnectionManager.Instance.StartGame();

        }

        public void OpenJoinPanel()
        {          
            Main_Menu.SetActive(false);
            inputPanel.SetActive(true);
        }

        public void JoinGroup()
        {
            
            PlayerJoinInfo.PlayerName = UserNameInput.text;
            NetworkConnectionManager.Instance.StartClient(ipInput.text);
            if(!string.IsNullOrEmpty(UserNameInput.text) || !string.IsNullOrEmpty(ipInput.text))
            {
                Main_Menu.SetActive(false);
                inputPanel.SetActive(false);
                JoinLobby.SetActive(true);
            }
            else
            {
                Debug.Log("Please enter valid UserName and IP Address");
            }
            
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
                NetworkConnectionManager.Instance.DisconnectClient();
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