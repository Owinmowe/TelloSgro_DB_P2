﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SQL_Login : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI username = null;
    [SerializeField] TextMeshProUGUI prueba = null;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/User Read.php", form);

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);
        prueba.text = www.downloadHandler.text;

    }
}
