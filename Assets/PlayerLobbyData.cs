using Unity.Netcode;
using UnityEngine;
using Unity.Collections;

public class PlayerLobbyData : NetworkBehaviour
{
    public static PlayerLobbyData Instance;
    public NetworkList<FixedString64Bytes> playerNames;

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

        playerNames = new NetworkList<FixedString64Bytes>();
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
            playerNames.Clear();
    }

    [ServerRpc(RequireOwnership = false)]
    public void AddPlayerNameServerRpc(string name)
    {
        if(!playerNames.Contains(name))
            playerNames.Add(name);
    }

    [ServerRpc(RequireOwnership = false)]
    public void RemovePlayerNameServerRpc(string name)
    {
        if(playerNames.Contains(name))
            playerNames.Remove(name);
    }
}
