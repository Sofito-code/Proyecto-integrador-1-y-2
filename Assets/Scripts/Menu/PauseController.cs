using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseController : MonoBehaviour
{
    public static bool gameisPaused = false;
    public GameObject pauseMenuUI;
    
    public GameObject pauseButton;
    public Sprite[] pauseSprites;

    private void Start() { 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Action();
        }
    }

    public void Action()
    {
        if (gameisPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameisPaused = false;
        pauseButton.GetComponent<Button>().image.sprite = pauseSprites[0];
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameisPaused = true;
        pauseButton.GetComponent<Button>().image.sprite = pauseSprites[1];
    }
}
