using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_EndScene : MonoBehaviour
{
    [SerializeField] List<UI_Component> endScene_HUD = null;
    [SerializeField] TextMeshProUGUI scoreText;

    string handlerText;

    private void Awake()
    {
        StartCoroutine(SQL_Connection.SendScoreRegister());
        StartCoroutine(SQL_Connection.RankingRegister());
        SQL_Connection.OnLastRequestEnded += SetHandler;
    }

    private void Start()
    {
        foreach (var item in endScene_HUD)
        {
            item.TransitionIn();
        }
        SessionData currentData = LoaderManager.Get().GetSessionData();
        scoreText.text = currentData.username + "\n Score: " + currentData.score + " Deaths: " + currentData.deaths;
    }

    void SetHandler()
    {
        handlerText = SQL_Connection.GetHandlerText();
        Debug.Log(handlerText);
    }

    public void BackToMenu()
    {
        LoaderManager.Get().LoadSceneAsync("Start Scene");
    }

    public void PlayAgain()
    {
        LoaderManager.Get().LoadSceneAsync("Main Game");
    }

}
