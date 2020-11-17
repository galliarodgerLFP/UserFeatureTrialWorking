using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBehaviour : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject RegScreen;
    public GameObject LogScreen;
    public GameObject DetailScreen; //where user info should show

    public static MainBehaviour Instance;
    public WebFin Webfin;
    public UserInfo userinfo;
    public LoginUser loginUser;


    // Start is called before the first frame update
    void Start()
    {
        SetHomeActive();
        //SetLogActive();
        Instance = this;
        Webfin = GetComponent<WebFin>();
        userinfo = GetComponent<UserInfo>();
    }

    #region
    //VIEWS
    public void SetHomeActive()
    {
        HomeScreen.SetActive(true);
        RegScreen.SetActive(false);
        LogScreen.SetActive(false);
        DetailScreen.SetActive(false);
    }

    public void SetRegActive()
    {
        HomeScreen.SetActive(false);
        RegScreen.SetActive(true);
        LogScreen.SetActive(false);
        DetailScreen.SetActive(false);
    }

    public void SetLogActive()
    {
        HomeScreen.SetActive(false);
        RegScreen.SetActive(false);
        LogScreen.SetActive(true);
        DetailScreen.SetActive(false);
    }

    public void SetDetailActive()
    {
        HomeScreen.SetActive(false);
        RegScreen.SetActive(false);
        LogScreen.SetActive(false);
        DetailScreen.SetActive(true);
    }

    #endregion
}
