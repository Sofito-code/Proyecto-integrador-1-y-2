using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Question : MonoBehaviour
{
    public GameObject parent;
    public GameObject title;
    public GameObject answer1;
    public GameObject answer2;
    public string rightAnswer { set; get; }
    public string id { set; get; }
    public bool isChoseCorrect { set; get; } = false;
    public bool answered { set; get; } = false;


    private void OnTriggerEnter(Collider other)
    {       
        answered = true;
        string a1 = answer1.GetComponent<Answer>().chosenOne;
        string a2 = answer2.GetComponent<Answer>().chosenOne;
        if (a1.Equals(rightAnswer)|| a2.Equals(rightAnswer))
        {
            isChoseCorrect = true;
        }
        parent.SetActive(false);
    }
}
