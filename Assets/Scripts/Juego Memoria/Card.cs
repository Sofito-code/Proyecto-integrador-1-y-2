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

    private void Start() { 

        HideCard();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SeeImage();
        info.SetActive(true);
    }

    public void SetImage(Sprite _sprite)
    {
        spriteShown = _sprite;
    }

    public void SeeImage()
    {
        GetComponent<Image>().sprite = spriteShown;
        Invoke("HideCard", delay);
    }

    public void HideCard()
    {
        info.SetActive(false);
        GetComponent<Image>().sprite = spriteHidden;
    }

    public void SetText(String text)
    {
        info = this.transform.GetChild(0).gameObject;
        info.GetComponent<Text>().text = text;
    }
}
