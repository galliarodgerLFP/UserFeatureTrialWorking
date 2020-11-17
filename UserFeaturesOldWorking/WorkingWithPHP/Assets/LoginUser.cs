using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUser : MonoBehaviour
{

    public Button submitBtn;
    public Button backBtn;
    public InputField userField;
    public InputField passwField;

    // Start is called before the first frame update
    void Start()
    {
        submitBtn.onClick.AddListener(() =>
        {
            StartCoroutine(MainBehaviour.Instance.Webfin.LoginUser(userField.text, passwField.text));
        });

        backBtn.onClick.AddListener(() =>
        {
            MainBehaviour.Instance.SetHomeActive();
        });

    }


}
