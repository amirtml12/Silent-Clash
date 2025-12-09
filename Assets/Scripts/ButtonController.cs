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
            MirrorNetworkManager.Instance.StartHost();
            Main_Menu.SetActive(false);
            HostLobby.SetActive(true);
           


        }

        public void StartGame()
        {
           MirrorNetworkManager.Instance.StartGame();

        }

        public void OpenJoinPanel()
        {          
            Main_Menu.SetActive(false);
            inputPanel.SetActive(true);
        }

        public void JoinGroup()
        {
            MirrorNetworkManager.Instance.StartClient(ipInput.text);
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