using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailId;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private Button loginButton;

    [SerializeField] private LoginCredentials credentials;

    private void Start()
    {
        credentials.SetCredentialsData();
        loginButton.onClick.AddListener(CheckLogin);
    }

    private void CheckLogin() 
    {
        credentials.ValidateLogin(emailId.text, password.text);
    }
}
