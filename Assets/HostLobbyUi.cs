using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;
using Unity.Collections;

public class HostLobbyUI : MonoBehaviour
{
    public Transform playersContainer;
    public GameObject playerItemPrefab;

    private PlayerLobbyData lobbyData;

    private void OnEnable()
    {
        
        TryInitialize();
    }

    private void TryInitialize()
    {
        if (PlayerLobbyData.Instance != null && PlayerLobbyData.Instance.playerNames != null)
        {
            lobbyData = PlayerLobbyData.Instance;
            lobbyData.playerNames.OnListChanged += OnPlayerListChanged;

            
            RefreshUI();
        }
        else
        {
        
            Invoke(nameof(TryInitialize), 0.1f);
        }
    }

    private void OnPlayerListChanged(NetworkListEvent<FixedString64Bytes> changeEvent)
    {
        RefreshUI();
    }

    private void RefreshUI()
    {
        foreach (Transform child in playersContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var name in lobbyData.playerNames)
        {
            GameObject item = Instantiate(playerItemPrefab, playersContainer);
            item.GetComponentInChildren<TMP_Text>().text = name.ToString();
        }
    }
}
