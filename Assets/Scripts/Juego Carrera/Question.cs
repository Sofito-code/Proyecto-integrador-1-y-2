using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Question : MonoBehaviour
{
    public GameObject title;
    public GameObject answer1;
    public GameObject answer2;
    public string rightAnswer;
    public string id;
    public bool isChoseCorrect { set; get; } = false;

    private void OnTriggerEnter(Collider other)
    {       
        string a1 = answer1.GetComponent<Answer>().chosenOne;
        if (a1.Equals(rightAnswer))
        {
            isChoseCorrect = true;
        }
    }
}
