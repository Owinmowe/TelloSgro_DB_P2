using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;


public class SQL_SendScore : MonoBehaviour
{

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        SessionData currentSessionData = LoaderManager.Get().GetSessionData();

        WWWForm form = new WWWForm();
        form.AddField("username", currentSessionData.username);
        form.AddField("score", currentSessionData.score);
        form.AddField("deaths", currentSessionData.deaths);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/Score Create.php", form);

        yield return www.SendWebRequest();

        //if (www.result == UnityWebRequest.Result.Success)
        //    Debug.Log("User: " + username.text + ". Successfully Sent!");

        Debug.Log(www.downloadHandler.text);

    }
}