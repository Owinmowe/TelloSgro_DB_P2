using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;

public class UI_MainMenu : MonoBehaviour
{

    [Header("Main Menu")]
    [SerializeField] List<UI_Component> mainMenu_HUD = null;

    [Header("Log In/Sign Up")]
    [SerializeField] List<UI_Component> LogIn_HUD = null;
    [SerializeField] TextMeshProUGUI usernameText = null;
    [SerializeField] TextMeshProUGUI passwordText = null;
    [SerializeField] TextMeshProUGUI errorText = null;


    private void Start()
    {
        foreach (var item in mainMenu_HUD)
        {
            item.TransitionIn();
        }
    }

    public void StartMainMenu()
    {
        foreach (var item in mainMenu_HUD)
        {
            item.TransitionIn();
        }
        foreach (var item in LogIn_HUD)
        {
            item.TransitionOut();
        }
    }

    public void StartLogInMenu()
    {
        foreach (var item in mainMenu_HUD)
        {
            item.TransitionOut();
        }
        foreach (var item in LogIn_HUD)
        {
            item.TransitionIn();
        }
    }

    public void CallLoginRegister()
    {
        StartCoroutine(SQL_Connection.LoginRegister(usernameText.text, passwordText.text, errorText));
        if(SQL_Connection.IsLoginCorrect()) LoaderManager.Get().LoadSceneAsync("Main Game");
    }

    public void CallSignUpRegister()
    {
        StartCoroutine(SQL_Connection.SignUpRegister(usernameText.text, passwordText.text, errorText));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}

