﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SQL_Connection : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI username = null;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/send.php", form);

        yield return www.SendWebRequest();
        
        if (www.result == UnityWebRequest.Result.Success)
            Debug.Log("User: " + username.text + ". Successfully Sent!");
    }
}