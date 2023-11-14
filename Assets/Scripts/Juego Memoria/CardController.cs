using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using static CardInfo;

public class CardController : MonoBehaviour
{
    public GameObject CardPrefab;
    public int cols;
    public int row;
    public Transform cardsParent;
    public Sprite[] sprites;
    public TMP_Text levelGame;
    public TMP_Text attempts;
    public TMP_Text successes;
    public TMP_Text time;
    public TMP_Text score;
    public TMP_Text scoreGameOver;
    public TMP_Text bonusGameOver;
    public TMP_Text totalGameOver;
    public GameObject gameOver;
    public GameObject pause;
    public Sprite[] pauseSprites;
    public GameObject gameInfoSup;
    public GameObject gameInfoInf;
    public GameObject cardsParentObject;
    public GameObject instructions;
    public float limit = 900f;    

    private List<CardInfo> questions;
    private List<GameObject> cards = new List<GameObject>();
    private int remainingClicks = 20;
    private int successesCards = 0;
    private int scorePlayer = 0;
    private int bonusScorePlayer = 0;
    private int level;
    private static bool gameisPaused = false;

    private Card displayedCard;
    public bool isAvailable { set; get; } = true;
    private bool playing = false;
    private float temp = 0f;
    private string textTime = "00:00";    


    //Card DAO for accessing to Data by JSON file
    private CardDAO cardDAO;

    void Start()
    {
        FindObjectOfType<SoundManager>().Change("Cartas");
        cardDAO = this.GetComponent<CardDAO>();
        cardDAO.ReadInfo();       
        cardDAO.SaveQuestionJson();
        level = cardDAO.puntajesArray.puntajes[0].level;
        questions = Levels(level);
        levelGame.text = "NIVEL: " + level;
        Create();
    }

    // Update is called once per frame
    void Update()
    {
        if(playing){
            if(temp>= limit || remainingClicks == 0 || successesCards == 7){
                GameOver();
            }
            UploadTimeUI();           
        }
    }

    public void ReloadGame(){
        this.remainingClicks = 20;
        this.successesCards = 0;
        this.scorePlayer = 0;
        this.bonusScorePlayer = 0;
        this.playing = false;
        this.temp = 0f;
        this.textTime = "00:00";
        time.text = "TIEMPO: " + textTime;
        gameInfoInf.transform.GetChild(5).gameObject.GetComponent<Button>().image.sprite= pauseSprites[0];
        pause.SetActive(false);
        Time.timeScale = 1f;
        gameisPaused = false;
        playing = true;
        UploadUI();
        cards.Clear();
        int children = cardsParent.childCount;
        for (int i = 0; i < children; ++i)
            Destroy(cardsParent.GetChild(i).gameObject);       
        Start();
        instructions.SetActive(true);
        gameInfoInf.SetActive(false);
        gameInfoSup.SetActive(false);
        cardsParentObject.SetActive(false);
        playing = false;
    }

    public void PauseGame()
    {
        if (gameisPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        gameInfoInf.transform.GetChild(5).gameObject.GetComponent<Button>().image.sprite= pauseSprites[0];
        pause.SetActive(false);
        Time.timeScale = 1f;
        gameisPaused = false;
        playing = true;
    }

    void Pause()
    {
        gameInfoInf.transform.GetChild(5).gameObject.GetComponent<Button>().image.sprite= pauseSprites[1];
        pause.SetActive(true);
        Time.timeScale = 0f;
        gameisPaused = true;         
        playing = false;
    }
    

    public void StartGame()
    {
        instructions.SetActive(false);
        gameInfoInf.SetActive(true);
        gameInfoSup.SetActive(true);
        cardsParentObject.SetActive(true);
        playing = true;
    }

    public void UploadTimeUI(){
        temp += Time.deltaTime;
        int hor, min, seg; 
        hor = (int)(temp / 3600);
        min = (int)((temp - hor * 3600) / 60);
        seg = (int)(temp - (hor * 3600 + min * 60));
        
        if(min < 10 && seg < 10){
            textTime = "0" + min + ":0" + seg;
        }else if(min < 10 && seg > 9){
            textTime = "0" + min + ":" + seg;
        }else if (min > 9 && seg < 10){
            textTime = min + ":0" + seg;
        }else{
            textTime = min + ":" + seg;
        }
        time.text = "TIEMPO: " + textTime;
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
                    scorePlayer += 50;
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
        score.text = "PUNTAJE: " + scorePlayer;
    }

    public void GameOver(){
        if(remainingClicks != 0 && successesCards == 7){
            for (var i = 0; i < remainingClicks; i++)
            {
                bonusScorePlayer += 25;
            }
        }
        cardsParentObject.SetActive(false);
        gameInfoSup.SetActive(false);
        gameInfoInf.SetActive(false);
        scoreGameOver.text = "PUNTAJE: " + scorePlayer;
        bonusGameOver.text = "BONUS: " + bonusScorePlayer;
        totalGameOver.text = "TOTAL: " + (scorePlayer + bonusScorePlayer);
        cardDAO.puntajesArray.puntajes[0].score += (scorePlayer + bonusScorePlayer);
        cardDAO.SaveCardLevel();
        int pieces = (scorePlayer + bonusScorePlayer) / 135;
        cardDAO.jugador.available_pieces += pieces;
        cardDAO.SaveJugador();
        gameOver.SetActive(true); 
        playing = false;
    }

    public void buttonBack(){
        LevelLoader.LoadLevel(1);
    }

    public void Shuffle<CardInfo>(List<CardInfo> list)  
    {  
        System.Random rng = new System.Random();
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = rng.Next(n + 1);  
            CardInfo value = list[k];  
            list[k] = list[n];  
            list[n] = value;  
        }  
    }

    private List<CardInfo> Levels(int level)
    {
        CardInfo[] data = UploadData();
        List<CardInfo> cardList = new List<CardInfo>();
        foreach (CardInfo item in data)
        {
            if (item.level == level)
            {
                cardList.Add(item);
            }
        }
        Shuffle(cardList);
        return cardList;
    }

    private CardInfo[] UploadData()
    {         
        CardInfo[] cardsQuestions = cardDAO.ReadQuestionJson();
        return cardsQuestions;
    }
}