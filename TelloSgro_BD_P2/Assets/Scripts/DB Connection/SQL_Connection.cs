using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class SQL_Connection : MonoBehaviour
{
    public void CallRegister(string username)
    {
        StartCoroutine(Register(username));
    }

    IEnumerator Register(string username)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/register.php", form);

        yield return www.SendWebRequest();

        Debug.Log(www.isDone);
    }
}
