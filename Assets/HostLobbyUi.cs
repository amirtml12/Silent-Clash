using UnityEngine;
using TMPro;
using Unity.Netcode;
using Unity.Collections;

public class HostLobbyUI : MonoBehaviour
{
    public Transform playersContainer;
    public GameObject playerItemPrefab;
    private PlayerLobbyData lobbyData;

    private void Awake()
    {
        // subscribe همیشگی حتی اگر Panel غیر فعال باشد
        if(PlayerLobbyData.Instance != null)
        {
            lobbyData = PlayerLobbyData.Instance;
            lobbyData.playerNames.OnListChanged -= OnPlayerListChanged;
            lobbyData.playerNames.OnListChanged += OnPlayerListChanged;

            // نمایش فوری همه اسامی موجود
            RefreshUI();
        }
    }

    private void OnDestroy()
    {
        if(lobbyData != null)
            lobbyData.playerNames.OnListChanged -= OnPlayerListChanged;
    }

    private void OnPlayerListChanged(NetworkListEvent<FixedString64Bytes> changeEvent)
    {
        RefreshUI();
    }

    public void RefreshUI()
    {
        foreach(Transform child in playersContainer)
            Destroy(child.gameObject);

        foreach(var name in lobbyData.playerNames)
        {
            GameObject item = Instantiate(playerItemPrefab, playersContainer);
            item.GetComponentInChildren<TMP_Text>().text = name.ToString();
        }
    }
}
