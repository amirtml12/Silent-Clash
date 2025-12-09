using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using SilentClash; // اگر از این Namespace استفاده می‌کنید

public class MirrorNetworkManager : MonoBehaviour
{
    
    private NetworkManager manager; 
    public static MirrorNetworkManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            manager = GetComponent<NetworkManager>();
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void StartHost()
    {
        manager.StartHost();
    }

    public void StartClient(string ip)
    {
        
        manager.networkAddress = ip;
        manager.StartClient();
    }

    public void StartGame()
    {
       
        if (NetworkServer.active) 
        {
            manager.ServerChangeScene(manager.onlineScene);
        }
    }

    public void StopHost()
    {
        if (NetworkServer.active)
            manager.StopHost();
    }

    public void DisconnectClient()
    {
        if (NetworkClient.active && !NetworkServer.active)
            manager.StopClient();
    }
}