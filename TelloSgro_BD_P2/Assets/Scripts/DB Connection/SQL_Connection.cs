using System;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

static public class SQL_Connection
{

    static public Action OnLastRequestEnded;

    static string handlerText = "";

    static public string GetHandlerText() => handlerText;

    public static IEnumerator LoginRegister(string username, string password, TextMeshProUGUI errorText)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/User Read.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success && www.downloadHandler.text[0] != '*')
        {
            errorText.color = Color.green;
            errorText.text = "Logged In. Have Fun!";
            LoaderManager.Get().SetSessionData(username, 0, 0);
            LoaderManager.Get().LoadSceneAsync("Main Game");
        }
        else
        {
            errorText.color = Color.red;
            errorText.text = "Can't login with current username/password.";
        }

        handlerText = www.downloadHandler.text;
        OnLastRequestEnded?.Invoke();
    }

    public static IEnumerator SignUpRegister(string username, string password, TextMeshProUGUI errorText)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/User Create.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success && www.downloadHandler.text[0] != '*')
        {
            errorText.color = Color.green;
            errorText.text = "Username created correctly.";

        }
        else
        {
            errorText.color = Color.red;
            errorText.text = "Can't sign up current username/password.";
        }

        handlerText = www.downloadHandler.text;
        OnLastRequestEnded?.Invoke();
    }

    public static IEnumerator SendScoreRegister()
    {
        SessionData currentSessionData = LoaderManager.Get().GetSessionData();

        WWWForm form = new WWWForm();
        form.AddField("username", currentSessionData.username);
        form.AddField("score", currentSessionData.score);
        form.AddField("deaths", currentSessionData.deaths);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/Score Insert.php", form);

        yield return www.SendWebRequest();

        handlerText = www.downloadHandler.text;
        OnLastRequestEnded?.Invoke();
    }

    public static IEnumerator RankingRegister()
    {
        WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/Score Ranking.php", form);

        yield return www.SendWebRequest();

        handlerText = www.downloadHandler.text;
        OnLastRequestEnded?.Invoke();
    }

}
