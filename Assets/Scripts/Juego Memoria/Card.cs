using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public Sprite spriteShown;
    public Sprite spriteHidden;
    public int idCard = 0;
    public GameObject info;
    public int topic { set; get; }
    public Vector3 originalPos { set; get; }
    public float delay;    
    public GameObject controller;

    public bool showing = false;

    private void Awake()
    {
        controller = GameObject.Find("Canvas");
    }

    private void Start() { 

        HideCard();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SeeImage();        
    }

    public void SetImage(Sprite _sprite)
    {
        spriteShown = _sprite;
    }

    public void SeeImage()
    {        
        if (!showing && controller.GetComponent<CardController>().isAvailable)
        {
            showing = true;
            info.SetActive(true);
            GetComponent<Image>().sprite = spriteShown;
            controller.GetComponent<CardController>().onCardClick(this);
        }
    }

    public void HideCard()
    {
        Invoke("Hide", delay);
        controller.GetComponent<CardController>().isAvailable = false;
    }

    private void Hide(){
        showing = false;
        info.SetActive(false);
        GetComponent<Image>().sprite = spriteHidden;        
        controller.GetComponent<CardController>().isAvailable = true;
    }

    public void SetText(String text)
    {
        info = this.transform.GetChild(0).gameObject;
        info.GetComponent<Text>().text = text;
    }
}
