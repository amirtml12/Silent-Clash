using Unity.Netcode;
using UnityEngine;
using Unity.Collections;

public class PlayerData : NetworkBehaviour
{
    public NetworkVariable<FixedString32Bytes> playerName =
        new NetworkVariable<FixedString32Bytes>("Unnamed",
        NetworkVariableReadPermission.Everyone,
        NetworkVariableWritePermission.Owner);

    public override void OnNetworkSpawn()
    {
        if (IsOwner)
        {
            playerName.Value = PlayerInfo.LocalPlayerName;
        }
    }
}
