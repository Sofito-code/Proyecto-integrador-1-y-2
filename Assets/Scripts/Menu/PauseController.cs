using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public static bool gameisPaused = false;
    public GameObject pauseMenuUI;

        void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){

            if(gameisPaused){
                Resume();
            }

            else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
         Time.timeScale = 1f;
         gameisPaused = false;

    }


    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameisPaused = true;

    }
}
