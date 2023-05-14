using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private float temp = 0f;
    private float limit = 35f;
    private bool isSkiped = false;
    public GameObject canvas;
    public GameObject menu;
    // Start is called before the first frame update
    void Update()
    {
        if(!isSkiped){
            temp += Time.deltaTime;
            if (temp >= limit)
            {
                Skip();
            }
        }
    }

    public void Skip(){
        isSkiped = true;
        canvas.SetActive(false);
        menu.SetActive(true);
    }
    
}
