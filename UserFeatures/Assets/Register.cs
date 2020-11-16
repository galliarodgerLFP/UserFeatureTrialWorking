using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public Button submitBtn;
    public Button backBtn;
    public InputField usernameField;
    public InputField passw1Field;
    public InputField passw2Field;
    public InputField levelField;


    void Start()
    {
        submitBtn.onClick.AddListener(() =>
        {
            StartCoroutine(Main.instance.webcomm.RegisterUser(usernameField.text, passw1Field.text, passw2Field.text, levelField.text));
        });
        backBtn.onClick.AddListener(() =>
        {
            Main.instance.SetHomeScreenActive();
        });


    }

}
