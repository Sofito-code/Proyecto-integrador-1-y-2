using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{
    public string chosenOne { set; get; } = "";

    private void OnTriggerEnter(Collider other)
    {
        chosenOne = this.GetComponent<TMPro.TextMeshPro>().text;
    }
}
