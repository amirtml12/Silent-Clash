using UnityEngine;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class NetworkConnectionManager : MonoBehaviour
{
    public static NetworkConnectionManager Instance;

    public UnityTransport transport;

    void Awake()
    {
        Instance = this;
        transport = GetComponent<UnityTransport>();
    }

    public void StartHost()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void StopHost()
    {
        NetworkManager.Singleton.Shutdown();
    }

    public void StartClient(string ip)
    {
        transport.ConnectionData.Address = ip;
        NetworkManager.Singleton.StartClient();
    }
}
