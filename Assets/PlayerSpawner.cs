using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {

        if(!NetworkManager.Singleton.IsServer) return;

        foreach(var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            
            var player = Instantiate(playerPrefab);
            player.GetComponent<NetworkObject>().SpawnAsPlayerObject(client.ClientId, true);
        }
    }
}
