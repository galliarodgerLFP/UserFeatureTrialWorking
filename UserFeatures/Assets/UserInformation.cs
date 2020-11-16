using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{
    public string userID { get; private set; }
    public string userName, userPassword;
    public int level;

    public void SetInfo(string username, string password)
    {
        userName = username;
        userPassword = password;
    }

    public void SetID(string id)
    {
        userID = id;
    }

    public void IncLevel(int currLevel)
    {
        if(level != 0)
        {
            level++;
        }
        else
        {
            level = 1;
        }
    }

    public void FillDetails(string username, int level)
    {

    }
}
