using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
    public string gameSceneName = "Game";

    public override void OnStartServer()
    {
        base.OnStartServer();

    }

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);


        if (sceneName == gameSceneName)
        {
            foreach (var conn in NetworkServer.connections)
            {
                if (conn.Value.identity == null)
                {
                    OnServerAddPlayer(conn.Value);
                }
            }
        }
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {

        Transform startPos = GetStartPosition();
        GameObject player = Instantiate(playerPrefab, startPos ? startPos.position : Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
