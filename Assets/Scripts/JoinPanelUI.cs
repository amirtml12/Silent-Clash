using UnityEngine;
using TMPro;

public class JoinPanelUI : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField ipAddressInput;
    public NetworkConnectionManager networkManager; 

    public void OnJoinButtonClicked()
    {
        string username = usernameInput.text;
        string ipAddress = ipAddressInput.text;
        
        // اعتبار سنجی ساده
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(ipAddress))
        {
            Debug.LogError("لطفاً نام کاربری و آدرس IP میزبان را وارد کنید.");
            return; 
        }

        
      
        
        
        gameObject.SetActive(false);
    }
}