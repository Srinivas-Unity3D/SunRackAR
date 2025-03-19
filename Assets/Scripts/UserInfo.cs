using UnityEngine;
using TMPro;

public class UserInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI emailId;

    private void OnEnable()
    {
        UserProfileData userData = UIManager.Instance.userPrfileData;
        SetUserProfile(userData.userName, userData.emailId);
    }

    private void SetUserProfile(string name, string email) 
    {
        userName.text = name;
        emailId.text = email; 
    }
}
