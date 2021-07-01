using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

static public class SQL_Connection
{

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
            LoaderManager.Get().LoadSceneAsync("Main Game");
        }
        else
        {
            errorText.color = Color.red;
            errorText.text = "Can't login with current username/password.";
        }
        Debug.Log(www.downloadHandler.text);
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
    }
}
