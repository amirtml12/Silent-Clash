using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkConnectionManager : MonoBehaviour
{
    public static NetworkConnectionManager Instance;

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            if (id == NetworkManager.Singleton.LocalClientId)
            {
                var lobby = PlayerLobbyData.Instance;
                if (lobby != null)
                {
                    lobby.AddPlayerNameServerRpc(PlayerJoinInfo.PlayerName);
                }
            }
        };
    }


    void Awake()
    {
        
        Instance = this;
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
        Debug.Log("Host Started");
    }

    public void StartClient(string ip)
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ip;

        NetworkManager.Singleton.StartClient();
        Debug.Log("Client Connecting to " + ip);
    }

    public void StopHost()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            NetworkManager.Singleton.Shutdown();
            Debug.Log("Host Stopped");
        }
    }

    public void StartGame()
    {
            if (NetworkManager.Singleton.IsServer)
            {
                NetworkManager.Singleton.SceneManager.LoadScene("Game", LoadSceneMode.Single);
            }

    }
}
