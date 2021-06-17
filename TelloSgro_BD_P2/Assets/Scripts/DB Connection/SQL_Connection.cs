using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class SQL_Connection : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI username = null;
    [SerializeField] TextMeshProUGUI password = null;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/register.php", form);

        yield return www.SendWebRequest();


        Debug.Log(www.isDone);
    }
}
