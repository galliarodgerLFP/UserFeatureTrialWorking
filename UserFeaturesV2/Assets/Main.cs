using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //Screens
    public GameObject HomeScreen;
    public GameObject RegisterScreen;
    public GameObject LoginScreen;
    public GameObject DetailsScreen;

    //instances of class
    public static Main instance;
    public WebComm webcomm;
    public UserInformation userInfo;

    //for homepage
    public Button registerUser;
    public Button loginUser;

    void Start()
    {
        instance = this;
        SetHomeScreenActive();
        webcomm = GetComponent<WebComm>();
        userInfo = GetComponent<UserInformation>();

        registerUser.onClick.AddListener(() =>
        {
            SetRegisterActive();
        });
        loginUser.onClick.AddListener(() =>
        {
            SetLoginActive();
        });

    }

    #region views
    public void SetHomeScreenActive()
    {
        HomeScreen.SetActive(true);
        RegisterScreen.SetActive(false);
        LoginScreen.SetActive(false);
        DetailsScreen.SetActive(false);
    }

    public void SetRegisterActive()
    {
        HomeScreen.SetActive(false);
        RegisterScreen.SetActive(true);
        LoginScreen.SetActive(false);
        DetailsScreen.SetActive(false);
    }

    public void SetLoginActive()
    {
        HomeScreen.SetActive(false);
        RegisterScreen.SetActive(false);
        LoginScreen.SetActive(true);
        DetailsScreen.SetActive(false);
    }

    public void SetDetailActive()
    {
        HomeScreen.SetActive(false);
        RegisterScreen.SetActive(false);
        LoginScreen.SetActive(false);
        DetailsScreen.SetActive(true);
    }

    #endregion

}
