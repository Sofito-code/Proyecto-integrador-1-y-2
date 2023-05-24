using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class QuestionController : MonoBehaviour
{
    private float[,] coordQuestions = new float[12, 3]
    {
        { 30.12f, 40.04f, 0f }, //
        { 0f, 40.04f, 0f },
        { -30.12f, 40.04f, 0f },
        { -65.323f, 26.01f, -60.628f },
        { -69.45f, 0f, -90f },
        { -65.323f, -26.01f, -119.372f },
        { -30.12f, -40.04f, 180f },
        { 0f, -40.04f, 180f },
        { 30.12f, -40.04f, 180f },
        { 65.323f, -26.01f, 119.372f },
        { 69.45f, 0f, 90f },
        { 65.323f, 26.01f, 60.628f }
    };

    public GameObject questionPrefab;
    public GameObject instructions;
    public GameObject gameInfoInf;
    public GameObject gameInfoSup;
    public GameObject pause;
    public Transform questionsParent;
    public string level;

    private List<QuestionInfo> questions;
    private List<GameObject> modules = new List<GameObject>();
    private bool playing = false;    
    private static bool gameisPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        questions = Levels(level);
        Create();
    }

    void Update()
    {
        if (playing)
        {
            /*             if(temp>= limit || remainingClicks == 0 || successesCards == 7){
                            GameOver();
                        }
                        UploadTimeUI();  */
            UploadUI();
        }

    }


    public void UploadUI(){

        gameInfoInf.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text = "RACHA DE ACIERTOS: " + 4;
    }

    public void Create()
    {
        for (int i = 0; i < 12; i++)
        {
            float x = coordQuestions[i, 0];
            float z = coordQuestions[i, 1];
            float y = coordQuestions[i, 2];
            GameObject questionTemp = Instantiate(
                questionPrefab,
                new Vector3(x, 2, z),
                Quaternion.Euler(new Vector3(0, y, 0))
            );
            modules.Add(questionTemp);
            questionTemp.transform.SetParent(questionsParent);
        }
        ModulesInfo();
    }

    public void ModulesInfo()
    {
        for (int i = 0; i < modules.Count; i++)
        {
            modules[i].GetComponent<Question>().title.GetComponent<TMPro.TextMeshPro>().text =
                questions[i].question;
            modules[i].GetComponent<Question>().answer1.GetComponent<TMPro.TextMeshPro>().text =
                questions[i].answer1;
            modules[i].GetComponent<Question>().answer2.GetComponent<TMPro.TextMeshPro>().text =
                questions[i].answer2;
            modules[i].GetComponent<Question>().id = questions[i].id;
            modules[i].GetComponent<Question>().rightAnswer = questions[i].rightAnswer;
        }
    }
    
    public void StartGame()
    {
        instructions.SetActive(false);
        gameInfoInf.SetActive(true);
        gameInfoSup.SetActive(true);
        questionsParent.gameObject.SetActive(true);
        playing = true;
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
        //gameInfoInf.transform.GetChild(5).gameObject.GetComponent<Button>().image.sprite= pauseSprites[0];
        pause.SetActive(false);
        Time.timeScale = 1f;
        gameisPaused = false;
        playing = true;
    }

    void Pause()
    {
        //gameInfoInf.transform.GetChild(5).gameObject.GetComponent<Button>().image.sprite= pauseSprites[1];
        pause.SetActive(true);
        Time.timeScale = 0f;
        gameisPaused = true;
        playing = false;
    }

    private List<QuestionInfo> Levels(string level)
    {
        QuestionInfo[] data = UploadData();
        List<QuestionInfo> questionList = new List<QuestionInfo>();
        foreach (QuestionInfo item in data)
        {
            if (item.level.Equals(level))
            {
                questionList.Add(item);
            }
        }
        Shuffle(questionList);
        return questionList;
    }

    public void Shuffle<QuestionInfo>(List<QuestionInfo> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            QuestionInfo value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private QuestionInfo[] UploadData()
    {
        string path = "Assets/Data/correr.txt";
        string[] text = File.ReadAllLines(path);
        int infoLength = text.Length;
        QuestionInfo[] data = new QuestionInfo[infoLength];
        for (int cont = 0; cont < infoLength; cont++)
        {
            string level = text[cont].Split('|')[0];
            string id = text[cont].Split('|')[1];
            string question = text[cont].Split('|')[2];
            string answer1 = text[cont].Split('|')[3];
            string answer2 = text[cont].Split('|')[4];
            QuestionInfo questionInfoTemp = new QuestionInfo(level, id, question, answer1, answer2);
            data[cont] = questionInfoTemp;
        }
        return data;
    }
}
