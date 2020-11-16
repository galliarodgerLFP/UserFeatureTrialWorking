using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
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
            StartCoroutine(Main.instance.webcomm.LoginUser(userField.text, passwField.text));
        });

        backBtn.onClick.AddListener(() =>
        {
            Main.instance.SetHomeScreenActive();
        });
    }


}
