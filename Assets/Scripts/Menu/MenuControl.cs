using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public void buttonBack()
    {
        SceneManager.LoadScene(0);
    }

    public void buttonStart()
    {
        LevelLoader.LoadLevel(1);
    }

    public void buttonInstructions()
    {
        SceneManager.LoadScene(3);
    }

    public void buttonCredits()
    {
        SceneManager.LoadScene(6);
    }

    public void buttonProgress()
    {
        SceneManager.LoadScene(7);
    }
    public void buttonOptions()
    {
        SceneManager.LoadScene(8);
    }
    public void buttonGalery()
    {
        SceneManager.LoadScene(9);
    }

    public void GoToFinalScene()
    {
        SceneManager.LoadScene(10);
    }

    public void buttonExit()
    {
        Application.Quit();
    }
}
