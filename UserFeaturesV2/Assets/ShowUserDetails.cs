using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class ShowUserDetails : MonoBehaviour
{
    public Text usernametxt;
    public Text leveltxt;
    public static ShowUserDetails showUserInstance;
    public Button backBtn;

    public Text contentNametxt1, contentNametxt2, contentNametxt3;
    public Text description1, description2, description3;

    // Start is called before the first frame update
    void Start()
    {
        showUserInstance = this; 
        backBtn.onClick.AddListener(() =>
        {
            Main.instance.SetHomeScreenActive();
        });
    }

    public void StartDetailProcess()
    {
        string username = Main.instance.userInfo.userName;
        StartCoroutine(Main.instance.webcomm.GetUserDetails(username));
    }

    public void FillDetails(string username, int level)
    {
        usernametxt.text = username;
        leveltxt.text = level.ToString() ; //int to string?
    }

}
