using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public Sprite sprite;
    public int idCard = 0;
    public GameObject info;
    public int topic {set; get;}

    public void OnPointerClick(PointerEventData eventData)
    {
        info.SetActive(true);
    }

    public void SetImage(Sprite _sprite){
        GetComponent<Image>().sprite = _sprite;
        sprite = _sprite;
    }

    public void SetText(String text){
        info = this.transform.GetChild(0).gameObject;
        info.GetComponent<Text>().text = text;
    }
}
