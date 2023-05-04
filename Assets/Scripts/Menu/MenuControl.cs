using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public void buttonStart(){
        SceneManager.LoadScene(1);
    }

    public void buttonCredit(){
        SceneManager.LoadScene(4);
    }

    public void buttonInstructions(){
        SceneManager.LoadScene(3);
    }

     public void buttonExit(){
        Application.Quit();
    }

     public void buttonBack(){
        SceneManager.LoadScene(0);
    }


}
