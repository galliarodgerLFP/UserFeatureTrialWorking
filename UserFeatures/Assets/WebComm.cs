using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public class WebComm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator RegisterUser(string username, string password1, string password2, string level)
    {
        //check passwords match
        if (password1 != password2)
        {
            UnityEngine.Debug.Log("passwords do not match");
        }
        else //register user
        {
            WWWForm form = new WWWForm();
            form.AddField("regUsername", username);
            form.AddField("regPassw", password1);
            var levelFin = int.Parse(level);
            //Int32.TryParse(level, out levelFin);
            form.AddField("regLevel", levelFin);

            using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/UserFeatureTrialPHP/registerUser.php", form))
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
    }

    public IEnumerator LoginUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        form.AddField("loginPassword", password);


        using (UnityWebRequest webRequest = UnityWebRequest.Post("http://localhost/UserFeatureTrialPHP/loginUser.php", form))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                UnityEngine.Debug.Log(webRequest.error);
            }
            else
            { 
                UnityEngine.Debug.Log(webRequest.downloadHandler.text); //should return an id
                Main.instance.userInfo.SetInfo(username, password);

                if (webRequest.downloadHandler.text.Contains("Wrong") || webRequest.downloadHandler.text.Contains("User DNE"))
                {
                    UnityEngine.Debug.Log("Try again, something went wrong :(");
                }
                else
                {
                    //if we log in correctly
                    Main.instance.SetDetailActive();
                    ShowUserDetails.showUserInstance.StartDetailProcess();

                }
            }
        }
    }

    public IEnumerator GetUserDetails(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername", username);
        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UserFeatureTrialPHP/ShowUser.php", form))
        {
            yield return www.Send();
            if (www.isNetworkError || www.isHttpError)
            {
                UnityEngine.Debug.Log(www.error);
            }
            else
            {
                UnityEngine.Debug.Log(www.downloadHandler.text); //in PHP side
                //get the JSON array from PHP
                string jsonArray = www.downloadHandler.text;
                
                //parse JSON format into readable from c#
                JSONArray userDetails = JSON.Parse(jsonArray) as JSONArray;
                /*debug code
                 * array should be formatted as [0][?] (only one user object)
                 * for example, userID is found at [0][0] and username [0][1]
                 */
                UnityEngine.Debug.Log("array received: " + jsonArray); //in C# side
                UnityEngine.Debug.Log("...now readable as " + userDetails);
                UnityEngine.Debug.Log("...userID is read as " + userDetails[0][0]);

                string userID = userDetails[0][0];
                string userName = userDetails[0][1];
                string userPassw = userDetails[0][2];
                int userLevel = userDetails[0][3];

                ShowUserDetails.showUserInstance.FillDetails(userName, userLevel);

            }
        }
    }

}
