using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInformation : MonoBehaviour
{
    public string userID { get; private set; }//is dbID
    public string userName, userPassword;
    public int level;
       
    public string name, surname, address, email, cell, landline, maritialStatus;
    public string race, gender, affiliate, idNum;

    public void SetInfo(string username, string password)
    {
        userName = username;
        userPassword = password;
    }

    public void SetAllInfo(string username, string password, int level, string name, string surname, string address, string gender, string email, string cell, string landline, string maritialStatus, string race, string affiliate, string idNum)
    {
        userName = username;
        userPassword = password;
        this.level = level;
        this.name = name;
        this.surname = surname;
        this.address = address;
        this.email = email;
        this.cell = cell;
        this.landline = landline;
        this.maritialStatus = maritialStatus;
        this.race = race;
        this.gender = gender;
        this.affiliate = affiliate;
        this.idNum = idNum;
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


}
