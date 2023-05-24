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
    public string rightAnswer;
    public string id;
    public bool isChoseCorrect { set; get; } = false;
    public bool answered { set; get; } = false;


    private void OnTriggerEnter(Collider other)
    {       
        answered = true;
        string a1 = answer1.GetComponent<Answer>().chosenOne;
        if (a1.Equals(rightAnswer))
        {
            isChoseCorrect = true;
        }
        parent.SetActive(false);
    }
}
