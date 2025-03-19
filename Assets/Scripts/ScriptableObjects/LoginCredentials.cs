using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "LoginCredentials", menuName = "Scriptable Objects/LoginCredentials")]
public class LoginCredentials : ScriptableObject
{
    [SerializeField] private List<LoginData> loginData = new List<LoginData>();
    private Dictionary<string, string> credentials = new Dictionary<string, string>();

    public void SetCredentialsData() 
    {
        foreach (LoginData data in loginData) 
        {
            if (!credentials.ContainsKey(data.emailId)) 
            {
                credentials.Add(data.emailId, data.password);
            }
        }
    }

    public (bool isEmailValid, bool isPasswordValid) ValidateLogin(string email, string password) 
    {
        if (credentials.TryGetValue(email, out string storedPassword)) 
        {
            bool isPasswordMatched = storedPassword == password;
            
            return (true, isPasswordMatched);
        }
        return (false, false);
    }
}


[Serializable]
public class LoginData 
{
    public string emailId;
    public string password;
}
