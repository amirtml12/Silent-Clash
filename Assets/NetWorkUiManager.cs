using UnityEngine;
using Mirror;

public class NetworkUIManager : MonoBehaviour
{
    public NetworkManager manager;

    public void StartHost()
    {
        manager.StartHost();
    }

    public void StopHost()
    {
        manager.StopHost();
    }

    public void StartClient(string ipAddress)
    {
        manager.networkAddress = ipAddress;
        manager.StartClient();
    }
    

    public void StopClient()
    {
        if (NetworkClient.isConnected)
            manager.StopClient();
    }
}
