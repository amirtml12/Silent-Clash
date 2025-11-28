using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    public static NetworkManager Instance;

    public const int DefaultPort = 7777;

    public string CurrentUsername { get; private set; }


    public List<PlayerInfo> ConnectedPlayers = new List<PlayerInfo>();
    
    private void Awake()
    {
        
            Instance = this;
            DontDestroyOnLoad(gameObject);  
    }

    public void ConnectToServer(string ipAddress, string port, string username)
    {
        
        CurrentUsername = username;
    
        int portNumber = DefaultPort;
        if (!int.TryParse(port, out portNumber))
        {
            Debug.LogError("پورت وارد شده نامعتبر است. از پورت پیش‌فرض استفاده شد.");
        }


        Debug.Log($"درخواست اتصال به IP: {ipAddress} در پورت: {portNumber} به عنوان {username}");

    }

    // NetworkManager.cs
    public void StartHost()
    {

        Debug.Log("هاست با موفقیت آغاز شد و در حال گوش دادن به اتصالات است.");

        string hostUsername = "نام_هاست_شما";

        PlayerInfo hostPlayer = new PlayerInfo
        {
            Username = hostUsername,
            IsHost = true
        };

        ConnectedPlayers.Add(hostPlayer);


        // LobbyUIManager.Instance.RefreshPlayerList();


        // SceneManager.LoadScene("LobbyScene");
    }

// NetworkManager.cs - این متد باید توسط سیستم شبکه‌سازی شما فراخوانی شود
public void HandleNewClientJoin(string receivedUsername)
{
    
    PlayerInfo newPlayer = new PlayerInfo 
    { 
        Username = receivedUsername, 
        IsHost = false 
    };
    ConnectedPlayers.Add(newPlayer);
    
    Debug.Log($"بازیکن جدید جوین شد: {receivedUsername}");


}

    public class PlayerInfo
    {
        public string Username;
        public bool IsHost;
    }
}

