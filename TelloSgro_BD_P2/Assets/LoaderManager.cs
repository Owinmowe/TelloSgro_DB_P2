using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionData
{
    public int score;
    public int deaths;
    public string username;
}

public class LoaderManager : MonoBehaviour
{

    private static LoaderManager instance = null;

    SessionData currentSessionData;

    static public LoaderManager Get()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance = null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSessionData(string username, int score, int deaths)
    {
        currentSessionData.username = username;
        currentSessionData.score = score;
        currentSessionData.deaths = deaths;
    }

    public SessionData GetSessionData()
    {
        return currentSessionData;
    }
}