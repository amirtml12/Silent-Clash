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
            Mirror.NetworkManager.singleton.StartHost();
            Main_Menu.SetActive(false);
            HostLobby.SetActive(true);
        }

        public void StartGame()
        {
            if (
                Mirror.NetworkServer.active)
            {
                foreach (var conn in Mirror.NetworkServer.connections)
                {
                    if (!conn.Value.isReady)
                        Mirror.NetworkServer.SetClientReady(conn.Value);
                }

                Mirror.NetworkManager.singleton.ServerChangeScene("Game");
            }
        }

        public void OpenJoinPanel()
        {

            Main_Menu.SetActive(false);
            inputPanel.SetActive(true);
        }

        public void JoinGroup()
        {
            string ip = ipInput.text;
            string playerName = UserNameInput.text;
           
            Mirror.NetworkManager.singleton.networkAddress = ip;
            Mirror.NetworkManager.singleton.StartClient();

            

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
                if (Mirror.NetworkServer.active)
                    Mirror.NetworkManager.singleton.StopHost();
                HostLobby.SetActive(false);
                Main_Menu.SetActive(true);
            }
            else if (gameObject.transform.parent.gameObject.tag == "JoinLobby")
            {
                if (Mirror.NetworkClient.isConnected)
                    Mirror.NetworkManager.singleton.StopClient();

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