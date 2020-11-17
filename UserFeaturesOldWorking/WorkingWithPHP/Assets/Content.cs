using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SimpleJSON;
using Newtonsoft.Json;

public class Content : MonoBehaviour
{
    Action<string> _createCallBack;
    public Text usernameTxt;
    public Text passwTxt;
    public Text extraTxt;
    public Text idTxt;
    public static Content content;

    // Start is called before the first frame update
    void Start()
    {
        content = this;
        

        //DoThing();
    }

    public void DoThing()
    {
        _createCallBack = (jsonArrayString) =>
        {
            StartCoroutine(CreateRoutine(jsonArrayString));
        };
        string username = MainBehaviour.Instance.userinfo.userName;
        StartCoroutine(MainBehaviour.Instance.Webfin.GetContent(username, _createCallBack)); //passed to web class
    }

    public IEnumerator CreateRoutine(string jsonArrayString)
    {
        //create thing where we instantiate prefab
        //getting info from web class and populate
        //STEP 1: parsing json array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray; //error
        
        /*  FIXING THE CODE
         *  could use the instanceof() to see if object or array and handle it differently
         *  JSONNode option?...
         *  JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.text);
         *  JSONUtility may not work because we don't have the right struct/classes (needs to be serializable)
         *  what if we just make a Node?  because Array is inherited from Node anyway?
         * 
         * */

        //says variable is variable but used as type

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //create local var
            bool isDone = false; //are we done downloading?
            string userid = jsonArray[i].AsObject["id"];
            JSONObject itemInfo = new JSONObject(); // should i be using "NEW"?

            //JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString());

            //create callback to get info from web class
            Action<string> getUserInfoCallback = (contentInfo) => //called from web class once item is downloaded
            {
                isDone = true;
                JSONArray tempArray = JSON.Parse(contentInfo) as JSONArray;
                
                contentInfo = tempArray.AsObject; //null exception error
                //UnityEngine.Debug.Log(contentInfo);
            };

            StartCoroutine(MainBehaviour.Instance.Webfin.GetContent(userid, getUserInfoCallback));
            //wait until callback is done
            yield return new WaitUntil(() => isDone == true);
            //instantiate gameobject content prefab
            usernameTxt.text = itemInfo["username"];
            passwTxt.text = itemInfo["password"];
            extraTxt.text = itemInfo["extra"];
            idTxt.text = itemInfo["id"];



        }

        yield return null;
    }
}
