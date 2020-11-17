using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;
using SimpleJSON;

public class WebFin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetUsers());
        //StartCoroutine(LoginUser("testing", "123"));
        //StartCoroutine(RegisterUser("test123","123","1223"));
    }

    /*public void ShowUserItems()
    {
        StartCoroutine(GetContentIDs(MainBehaviour.Instance.userinfo.userid));
    } *///ERROR HERE?


    public IEnumerator GetUsers()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("http://localhost/ForProj1PHP/getUsersFin.php"))
        {
            //request and wait for desired page
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                //UnityEngine.Debug.Log(pages[page] + ": Error: " + webRequest.error);
                UnityEngine.Debug.Log(webRequest.error);
            }
            else
            {
                //UnityEngine.Debug.Log(pages[page] + ":\nReceived" + webRequest.downloadHandler.text);
                UnityEngine.Debug.Log(webRequest.downloadHandler.text);

            }
        }
    }

    public IEnumerator LoginUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);


        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/ForProj1PHP/loginUsers.php", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                UnityEngine.Debug.Log(webRequest.error);
            }
            else
            {
                UnityEngine.Debug.Log(webRequest.downloadHandler.text); //should return an id
                MainBehaviour.Instance.userinfo.SetInfo(username, password);
                MainBehaviour.Instance.userinfo.SetID(webRequest.downloadHandler.text);


                if (webRequest.downloadHandler.text.Contains("Wrong") || webRequest.downloadHandler.text.Contains("User DNE"))
                {
                    UnityEngine.Debug.Log("Try again, something went wrong :(");
                }
                else
                {
                    //if we log in correctly
                    MainBehaviour.Instance.SetDetailActive();
                    realContent.content.DoThingV2();
                }
                
            }

        }
    }

    public IEnumerator RegisterUser(string username, string password, string extra)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
        form.AddField("extraStuff", extra);


        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/ForProj1PHP/registerUser.php", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                UnityEngine.Debug.Log(webRequest.error);
            }
            else
            {
                UnityEngine.Debug.Log(webRequest.downloadHandler.text);
            }

        }
    }

    public IEnumerator GetContent(string content_dbUsername, System.Action<string> callback) //npt working
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", content_dbUsername);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ForProj1PHP/ShowDetails.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;    //change to a normal array or a linked list
                UnityEngine.Debug.Log("array is " + jsonArray);

                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetDetails(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ForProj1PHP/ShowDetails.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;    //change to a normal array or a linked list
                UnityEngine.Debug.Log("array is " + jsonArray);

                //var details = JObject.Parse(); //into dictionary
                //UnityEngine.Debug.Log(details);
                JSONArray details = JSON.Parse(jsonArray) as JSONArray; //now an array?
                
                UnityEngine.Debug.Log(details); //looks the same as jsonArray but usable for details
                UnityEngine.Debug.Log(details[0][0]); //returns ID!!!

                string forID = details[0][0]; //id
                string forUsername = details[0][1];
                string forPassw = details[0][2];
                string forDetails = details[0][3];

                realContent.content.FillDetails(forID, forUsername, forPassw, forDetails);




            }
        }
    }
}

    /*public IEnumerator GetContentIDs(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginID", userID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/ForProj1PHP/showDetailUser.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;   

                callback(jsonArray);
            }
        }
    }

}*/
