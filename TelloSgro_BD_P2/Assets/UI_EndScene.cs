using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_EndScene : MonoBehaviour
{
    [SerializeField] List<UI_Component> endScene_HUD = null;
    [SerializeField] List<TextMeshProUGUI> scoreTexts = null;
    [SerializeField] TextMeshProUGUI scoreText = null;

    List<SessionData> rankingData = new List<SessionData>();

    private void Awake()
    {
        StartCoroutine(SQL_Connection.SendScoreRegister());
        StartCoroutine(SQL_Connection.RankingRegister());
        SQL_Connection.OnGetRankingRequestEnded += SetHighScore;
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

    void SetHighScore(string scoreText)
    {
        rankingData = new List<SessionData>();
        var newString = scoreText;
        var HighScoreStringArray = newString.Split('_');
        for (int i = 0; i < HighScoreStringArray.Length; i++)
        {
            var scoreComponent = HighScoreStringArray[i].Split('-');
            rankingData[i].username = HighScoreStringArray[0];
            rankingData[i].deaths = int.Parse(HighScoreStringArray[1]);
            rankingData[i].score = int.Parse(HighScoreStringArray[2]);
        }

        for (int i = 0; i < rankingData.Count; i++)
        {
            scoreTexts[i].text = rankingData[i].username + " " + rankingData[i].deaths + " " + rankingData[i].score;
        }
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
