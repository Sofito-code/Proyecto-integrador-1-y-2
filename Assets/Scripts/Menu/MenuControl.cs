using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public void buttonBack()
    {
        SceneManager.LoadScene(0);//Scene Menu
    }

    public void buttonStart()
    {
        LevelLoader.LoadLevel(1);//Scene Biblioteca
    }

    public void buttonInstructions()
    {
        SceneManager.LoadScene(3);//Scene Instrucciones
    }

    public void buttonCredits()
    {
        SceneManager.LoadScene(5);//Scene Credits
    }

    public void buttonProgress()
    {
        SceneManager.LoadScene(6);//Scene Progress
    }

    public void buttonOptions()
    {
        SceneManager.LoadScene(7);//Scene Options
    }

    public void buttonGalery()
    {
        SceneManager.LoadScene(8);//Scene Galery
    }

    public void GoToFinalScene()
    {
        SceneManager.LoadScene(9);//Scene FinalScene
    }

    public void buttonExit()
    {
        Application.Quit();
    }
}
