using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI emailId;

    [SerializeField] private bool isARMode;

    private void OnEnable()
    {
        isARMode = SceneManager.GetActiveScene().name.Equals(ScenesInBuild.ARScene);
        UserProfileData userData = new UserProfileData();
        if (isARMode)
        {
            userData = ARModeManager.Instance.globalVariables.userData;
        }
        else 
        {
            userData = UIManager.Instance.globalVariables.userData;
        }

        SetUserProfile(userData.userName, userData.emailId);
    }

    private void SetUserProfile(string name, string email) 
    {
        userName.text = name;
        emailId.text = email; 
    }
}
