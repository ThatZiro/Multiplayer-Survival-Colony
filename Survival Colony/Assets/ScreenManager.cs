using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{

    public enum Scene { Main, Settings, Credit, SelectCharacter, NewCharacter, SelectWorld, CreateWorld, JoinWorld}

    private Scene lastScene;
    public Scene currentScene;

    public GameObject Main_Screen;
    public GameObject Settings_Screen;
    public GameObject Credit_Screen;
    public GameObject SelectCharacter_Screen;
    public GameObject NewCharacter_Screen;
    public GameObject SelectWorld_Screen;
    public GameObject CreateWorld_Screen;
    public GameObject JoinWorld_Screen;

    private void Start()
    {
        //Initilize all scenes to stop error OnValidating
        Main_Screen.SetActive(true);
        Settings_Screen.SetActive(true);
        Credit_Screen.SetActive(true);
        SelectCharacter_Screen.SetActive(true);
        NewCharacter_Screen.SetActive(true);
        SelectWorld_Screen.SetActive(true);
        CreateWorld_Screen.SetActive(true);
        JoinWorld_Screen.SetActive(true);

        ChangeScene(currentScene);
    }
    public void ChangeScene(int sceneInt)
    {
        ChangeScene((Scene)sceneInt);
    }
    public void ChangeScene(Scene scene)
    {
        CloseAllScenes();

        switch (scene)
        {
            case Scene.Main:
                Main_Screen.SetActive(true);
                break;

            case Scene.Settings:
                Settings_Screen.SetActive(true);
                break;

            case Scene.Credit:
                Credit_Screen.SetActive(true);
                break;

            case Scene.SelectCharacter:
                SelectCharacter_Screen.SetActive(true);
                break;

            case Scene.NewCharacter:
                NewCharacter_Screen.SetActive(true);
                break;

            case Scene.SelectWorld:
                SelectWorld_Screen.SetActive(true);
                break;

            case Scene.CreateWorld:
                CreateWorld_Screen.SetActive(true);
                break;

            case Scene.JoinWorld:
                JoinWorld_Screen.SetActive(true);
                break;
        }
        lastScene = currentScene;
    }

    public void CloseAllScenes()
    {
        Main_Screen.SetActive(false);
        Settings_Screen.SetActive(false);
        Credit_Screen.SetActive(false);
        SelectCharacter_Screen.SetActive(false);
        NewCharacter_Screen.SetActive(false);
        SelectWorld_Screen.SetActive(false);
        CreateWorld_Screen.SetActive(false);
        JoinWorld_Screen.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    private void OnValidate()
    {
        if(currentScene != lastScene)
        {
            ChangeScene(currentScene);
        }
    }
}
