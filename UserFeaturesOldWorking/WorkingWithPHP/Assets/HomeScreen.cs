using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HomeScreen : MonoBehaviour
{
    public Button createUser;
    public Button loginUser;
    // Start is called before the first frame update
    void Start()
    {
        createUser.onClick.AddListener(() =>
        {
            MainBehaviour.Instance.SetRegActive();
        });

        loginUser.onClick.AddListener(() =>
        {
            MainBehaviour.Instance.SetLogActive();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
