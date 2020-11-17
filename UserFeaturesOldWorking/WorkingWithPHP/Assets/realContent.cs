using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using Newtonsoft.Json;

public class realContent : MonoBehaviour
{
    Action<string> _createCallBack;
    public Text usernameTxt;
    public Text passwTxt;
    public Text extraTxt;
    public Text idTxt;
    public static realContent content;

    // Start is called before the first frame update
    void Start()
    {
        content = this;
    }



    public void DoThingV2()
    {
        string username = MainBehaviour.Instance.userinfo.userName;
        StartCoroutine(MainBehaviour.Instance.Webfin.GetDetails(username)); //passed to web class
    }

    public void FillDetails(string id, string username, string password, string extra)
    {
        usernameTxt.text = username;
        idTxt.text = id;
        passwTxt.text = password;
        extraTxt.text = extra;

    }

}



