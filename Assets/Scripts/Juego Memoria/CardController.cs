using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;

public class CardController : MonoBehaviour
{
    public GameObject CardPrefab;
    public int cols;
    public int row;
    public Transform cardsParent;
    public Sprite[] sprites;
    public string level;
    List<CardInfo> questions;
    List<GameObject> cards = new List<GameObject>();
    public int remainingClicks = 20;
    public int successesCards = 0;
    public TMP_Text attempts;
    public TMP_Text successes;
    public Card displayedCard;

    public bool isAvailable = true;


    void Start()
    {
        questions = Levels(level);
        Create();
    }

    public void Create()
    {
        int x = 210;
        for (int i = 0; i < cols; i++)
        {
            int y = 740;
            for (int j = 0; j < row; j++)
            {
                GameObject cardTemp = Instantiate(
                    CardPrefab,
                    new Vector3(x, y, 0),
                    Quaternion.Euler(new Vector3(0, 0, 0))
                );
                cards.Add(cardTemp);
                
                cardTemp.GetComponent<Card>().originalPos = new Vector3(x, y, 0);
                cardTemp.transform.SetParent(cardsParent);
                y -= 400;
            }
            x += 250;
        }
        CardsInfo();
        RandomPositions();
    }

    void CardsInfo()
    {
        bool isQuestion = true;
        for (int i = 0; i < cards.Count; i++)
        {
            CardInfo question = questions[i/2];
            cards[i].GetComponent<Card>().SetImage(sprites[question.topic]);
            cards[i].GetComponent<Card>().topic = question.topic;
            cards[i].GetComponent<Card>().idCard = Int16.Parse(question.id);
            if (isQuestion)
            {
                cards[i].GetComponent<Card>().SetText(question.question);
                isQuestion = false;
            }
            else
            {
                cards[i].GetComponent<Card>().SetText(question.answer);
                isQuestion = true;
            }
        }
    }

    void RandomPositions(){
        int rd;
        for (int i = 0; i < cards.Count; i++)
        {
            rd = UnityEngine.Random.Range(i, cards.Count);
            cards[i].transform.position =  cards[rd].transform.position;
            cards[rd].transform.position = cards[i].GetComponent<Card>().originalPos;

            cards[i].GetComponent<Card>().originalPos = cards[i].transform.position;
            cards[rd].GetComponent<Card>().originalPos = cards[rd].transform.position;
        }
    }

    public void onCardClick(Card _card){
        if (displayedCard == null)
        {
            displayedCard = _card;
        }else{
            if(displayedCard != null){
                if(CompareCards(_card,displayedCard)){
                    successesCards++;
                }
                else{
                    _card.HideCard();
                    displayedCard.HideCard();
                }
                displayedCard = null;
            }
        }
        remainingClicks--;
        UploadUI();
    }

    public bool CompareCards(Card _card1, Card _card2){
        return _card1.idCard == _card2.idCard;
    }

    public void UploadUI(){
        attempts.text = "INTENTOS RESTANTES: " + remainingClicks;
        successes.text = "ACIERTOS: " + successesCards;
    }

    List<CardInfo> Levels(string level)
    {
        CardInfo[] data = UploadData();
        List<CardInfo> cardList = new List<CardInfo>();
        foreach (CardInfo item in data)
        {
            if (item.level.Equals(level))
            {
                cardList.Add(item);
            }
        }
        return cardList;
    }

    CardInfo[] UploadData()
    {
        string path = "Assets/Data/memoria.txt";
        string[] text = File.ReadAllLines(path);
        int infoLength = text.Length;
        CardInfo[] data = new CardInfo[infoLength];
        for (int cont = 0; cont < infoLength; cont++)
        {
            string level = text[cont].Split('|')[0];
            string id = text[cont].Split('|')[1];
            string question = text[cont].Split('|')[2];
            string answer = text[cont].Split('|')[3];
            int topic = Int16.Parse(text[cont].Split('|')[4]);
            CardInfo cardInfoTemp = new CardInfo(level, id, question, answer, topic);
            data[cont] = cardInfoTemp;
        }
        return data;
    }
}

class CardInfo
{
    public string level { get; }
    public string id { get; }
    public string question { get; }
    public string answer { get; }
    public int topic { get; }

    public CardInfo() { }

    public CardInfo(string level, string id, string question, string answer, int topic)
    {
        this.level = level;
        this.id = id;
        this.question = question;
        this.answer = answer;
        this.topic = topic;
    }
}
