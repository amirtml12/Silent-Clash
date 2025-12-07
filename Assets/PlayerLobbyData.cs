using Unity.Netcode;
using UnityEngine;
using Unity.Collections;

public class PlayerLobbyData : NetworkBehaviour
{
    public static PlayerLobbyData Instance;

    public NetworkList<FixedString64Bytes> playerNames;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    public override void OnNetworkSpawn()
    {
        if (IsServer)
        {
            playerNames = new NetworkList<FixedString64Bytes>();
        }

        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }

    private void OnClientConnected(ulong clientId)
    {
        if (IsServer)
        {
            AddPlayerNameServerRpc(PlayerJoinInfo.PlayerName);
        }
    }

    [ServerRpc(RequireOwnership = false)]
    public void AddPlayerNameServerRpc(string name)
    {
        playerNames.Add(name);
    }

   
}
