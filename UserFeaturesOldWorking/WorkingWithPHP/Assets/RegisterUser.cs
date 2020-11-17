using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterUser : MonoBehaviour
{
    public Button submitBtn;
    public Button backBtn;
    public InputField userField;
    public InputField passwField;
    public InputField extraField;

    // Start is called before the first frame update
    void Start()
    {
        submitBtn.onClick.AddListener(() =>
        {
            StartCoroutine(MainBehaviour.Instance.Webfin.RegisterUser(userField.text, passwField.text, extraField.text));
        });

        backBtn.onClick.AddListener(() =>
        {
            MainBehaviour.Instance.SetHomeActive();
        });
    }


}
