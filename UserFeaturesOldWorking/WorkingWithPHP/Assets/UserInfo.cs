using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public string userid { get; private set;}
    public string userName;
    public string userPassword;
    public string userExtra;


    public void SetInfo(string username, string userpassw)
    {
        userName = username;
        userPassword = userpassw;

    }

    public void SetID(string id)
    {
        userid = id;
    }
}
