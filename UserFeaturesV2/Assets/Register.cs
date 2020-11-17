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

    public InputField nameField;
    public InputField surnameField;
    public InputField affiliateField;
    public InputField genderField;
    public InputField maritialStatusField;
    public InputField cellField;
    public InputField landlineField;
    public InputField emailField;
    public InputField idField;
    public InputField raceField;
    public InputField addressField;

    void Start()
    {
        submitBtn.onClick.AddListener(() =>
        {
            StartCoroutine(Main.instance.webcomm.RegisterUser(usernameField.text, passw1Field.text, passw2Field.text, levelField.text, nameField.text, surnameField.text, addressField.text, emailField.text, cellField.text, landlineField.text, maritialStatusField.text, raceField.text, genderField.text, affiliateField.text, idField.text));
        });
        backBtn.onClick.AddListener(() =>
        {
            Main.instance.SetHomeScreenActive();
        });


    }

}
