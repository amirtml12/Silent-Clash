using SilentClash;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class NetworkConnectionManager : MonoBehaviour
{
    public static NetworkConnectionManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }

    private void OnClientConnected(ulong clientId)
{
    if (clientId == NetworkManager.Singleton.LocalClientId && !NetworkManager.Singleton.IsServer)
    {
        if (PlayerLobbyData.Instance != null)
        {
            PlayerLobbyData.Instance.AddPlayerNameServerRpc(PlayerJoinInfo.PlayerName);

           
            var hostLobbyUI = FindObjectOfType<HostLobbyUI>();
            if(hostLobbyUI != null)
                hostLobbyUI.RefreshUI();
        }
    }
}


    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();

        
    }


    public void StartClient(string ip)
    {
        var transport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        transport.ConnectionData.Address = ip;
        NetworkManager.Singleton.StartClient();
        if(PlayerLobbyData.Instance != null)
            PlayerLobbyData.Instance.AddPlayerNameServerRpc(PlayerJoinInfo.PlayerName);
    }

    public void StartGame()
    {
        if (NetworkManager.Singleton.IsServer)
            NetworkManager.Singleton.SceneManager.LoadScene("Game", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public void StopHost()
    {
        if (NetworkManager.Singleton.IsServer)
            NetworkManager.Singleton.Shutdown();
            PlayerLobbyData.Instance.playerNames.Clear();
    }

    public void DisconnectClient()
    {
    if (NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
    {
    
            PlayerLobbyData.Instance.RemovePlayerNameServerRpc(PlayerJoinInfo.PlayerName);

            NetworkManager.Singleton.Shutdown();

    }

    }




}
