using UnityEngine;
using TMPro;

public class LobbyUI : MonoBehaviour
{
    public Transform playersContainer;
    public GameObject playerItemPrefab;

    void OnEnable()
    {
        if (PlayerLobby.Instance != null)
        {
            UpdateUI();
            PlayerLobby.Instance.SubscribeToListChanges(UpdateUI);
        }
    }

    void UpdateUI()
    {
   
        foreach (Transform child in playersContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var name in PlayerLobby.Instance.playerNames)
        {
            GameObject item = Instantiate(playerItemPrefab, playersContainer);
            item.GetComponentInChildren<TMP_Text>().text = name;
        }
    }
}
