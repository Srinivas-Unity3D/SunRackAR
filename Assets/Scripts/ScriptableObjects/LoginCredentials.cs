using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LoginCredentials", menuName = "Scriptable Objects/LoginCredentials")]
public class LoginCredentials : ScriptableObject
{
    [SerializeField] private List<LoginData> loginData = new List<LoginData>();
    private Dictionary<string, UserData> credentials = new Dictionary<string, UserData>();

    public void SetCredentialsData() 
    {
        foreach (LoginData data in loginData) 
        {
            if (!credentials.ContainsKey(data.emailId)) 
            {
                credentials.Add(data.emailId, data.userdata);
            }
        }
    }

    public (bool isEmailValid, bool isPasswordValid) ValidateLogin(string email, string password) 
    {
        if (credentials.TryGetValue(email, out UserData userdata)) 
        {
            bool isPasswordMatched = userdata.password == password;
            
            return (true, isPasswordMatched);
        }
        return (false, false);
    }

    public UserProfileData GetProfileData(string email) 
    {
        UserProfileData userData = new UserProfileData();
        userData.emailId = email;

        if (credentials.TryGetValue(email, out UserData data)) 
        {
            userData.userName = data.userName;
        }

        return userData;
    }
}


[Serializable]
public class LoginData 
{
    public string emailId;
    public UserData userdata;
}

[Serializable]
public class UserData 
{
    public string password;
    public string userName;
}

