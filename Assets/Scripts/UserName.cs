using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UserName : MonoBehaviour 
{
    private string _userName;
    public string UserNickName { get { return _userName; } }
    public void SetUserName(string userName)
    {
        if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName) || Convert.ToUInt16(userName[0]) == 8203)
        {
            gameObject.GetComponent<TextMeshPro>().text = "Player";
            _userName = userName;
        }
        else
        {
            gameObject.GetComponent<TextMeshPro>().text = userName;
            _userName = userName;
        }
    }
}
