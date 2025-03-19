using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class LoginPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField emailId;
    [SerializeField] private TMP_InputField password;
    [SerializeField] private Button loginButton;
    [SerializeField] private LoginCredentials credentials;
    [SerializeField] private TextMeshProUGUI warningMessage;

    private void Start()
    {
        credentials.SetCredentialsData();
        loginButton.onClick.AddListener(ValidateLogin);
    }

    private void ValidateLogin()
    {
        if (!IsInputEntered()) return;

        (bool isEmailValid, bool isPasswordValid) result = credentials.ValidateLogin(emailId.text, password.text);
        if (!result.isEmailValid) 
        {
            StartCoroutine(ShowWarningMessage(2f, Messages.invalidEmail));
            return;
        }

        if (!result.isPasswordValid) 
        {
            StartCoroutine(ShowWarningMessage(2f, Messages.wrongPassword));
            return;
        }
        UIManager.Instance.userPrfileData = credentials.GetProfileData(emailId.text);
        StartCoroutine(ShowLoginSuccessful(2f));
    }

    private bool IsInputEntered() 
    {
        if (string.IsNullOrEmpty(emailId.text)) 
        {
            StartCoroutine(ShowWarningMessage(2f, Messages.emailField));
            return false;
        }

        if (string.IsNullOrEmpty(password.text)) 
        {
            StartCoroutine(ShowWarningMessage(2f, Messages.passwordField));
            return false;
        }

        return true;
    }

    private IEnumerator ShowWarningMessage(float timeDelay, string message) 
    {
        warningMessage.text = $"Warning: {message}";
        yield return new WaitForSeconds(timeDelay);
        warningMessage.text = string.Empty;
    }

    private IEnumerator ShowLoginSuccessful(float timeDelay) 
    {
        UIManager.Instance.alertPopup.Show("Login Status", "You Logged In Successfully", false, "", false, "");
        yield return new WaitForSeconds(timeDelay);
        ShowStructuralPanel();
        UIManager.Instance.alertPopup.Hide();
    }

    private void ShowStructuralPanel() 
    {
        UIManager.Instance.structuralPanel.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        emailId.text = string.Empty;
        password.text = string.Empty;
        warningMessage.text = string.Empty;
    }
}
