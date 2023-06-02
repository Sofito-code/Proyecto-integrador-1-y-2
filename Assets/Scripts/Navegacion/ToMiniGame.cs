using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMiniGame : MonoBehaviour
{
    public GameObject canvas;
    public int sceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        canvas.SetActive(true);
    }

    public void StartGame(){
        LevelLoader.LoadLevel(sceneNumber);
    }

    public void backToLibrary(){
        canvas.SetActive(false);
    }
}
