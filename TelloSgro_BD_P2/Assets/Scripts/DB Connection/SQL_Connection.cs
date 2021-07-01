using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

static public class SQL_Connection
{

    static bool LoginCorrect = false;

    static public bool IsLoginCorrect() => LoginCorrect;

    public static IEnumerator LoginRegister(string username, string password, TextMeshProUGUI errorText)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/User Read.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            errorText.color = new Color(0, 0, 0, 0);
            LoginCorrect = true;
        }
        else
        {
            errorText.color = Color.red;
            LoginCorrect = false;
            errorText.text = "Can't login with current username/password.";
        }
    }

    public static IEnumerator SignUpRegister(string username, string password, TextMeshProUGUI errorText)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/shooter/User Read.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
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
