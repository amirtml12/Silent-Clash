using UnityEngine;
using Mirror;

public class PlayerLobby : NetworkBehaviour
{
    public static PlayerLobby Instance;


    public readonly SyncList<string> playerNames = new SyncList<string>();

    void Awake()
    {
        Instance = this;
    }

   
    [Command(requiresAuthority = false)]
    public void CmdAddPlayerName(string playerName)
    {
        if (!playerNames.Contains(playerName))
            playerNames.Add(playerName);
    }

   
    public void SubscribeToListChanges(System.Action callback)
    {
        playerNames.Callback += (op, index, oldItem, newItem) => callback();
    }
}
