using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuestionController : MonoBehaviour
{
    private float[,] coordQuestions = new float[12, 3]
    {
        { 30.12f, 40.04f, 0f }, 
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

    public GameObject player;
    public GameObject questionPrefab;
    public GameObject instructions;
    public GameObject gameInfoInf;
    public GameObject gameInfoSup;
    public GameObject pauseCanvas;
    public GameObject gameOverCanvas;
    public Transform questionsParent;
    public Sprite[] pauseSprites;
    private string level;

    private int FinalScoring = 0;
    private int successes = 0;
    private int scoring = 0;
    private int bonusScore = 0;
    private int rate = 0;
    public int questionCheck = 0;
    public int wrongAnswers = 0;
    private int streakCounter = 0;
    private List<QuestionInfo> questions;
    private List<GameObject> modules = new List<GameObject>();
    public bool playing = false;
    private static bool gameisPaused = false;
    public Coroutine scoreC;

    private Carrera carreraDB = new Carrera();

    //Card DAO for accessing to Data by JSON file
    public QuestionDAO questionDAO;

    // Start is called before the first frame update
    void Start()
    {  
        QueryLevelDB();
        questions = Levels(level);
        Create();
    }

    void Update()
    {
        if (playing)
        {
            scoreC = StartCoroutine(Score());
            if (12 == questionCheck || 5 == wrongAnswers)
            {
                GameOver();
                if (questionCheck == 12)
                {
                    this.GetComponent<RunnerController>().StopSpawn();
                    StopCoroutine(scoreC);
                    VictoryAnimate();
                }
                if (wrongAnswers == 5)
                {
                    this.GetComponent<RunnerController>().StopSpawn();
                    StopCoroutine(scoreC);
                    DefeatAnimate();
                }
            }
        }else{
            QueryLevelDB();
        }
    }
    void QueryLevelDB(){
        level = this.GetComponent<DBManagement>().QueryRunnerLevel();
        this.GetComponent<DBManagement>().CloseConn();
        gameInfoSup.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text =
            "NIVEL: " + level;
    }
    void VictoryAnimate()
    {
        player.transform.GetChild(0).GetComponent<Animator>().SetBool("Victory", true);
    }

    void DefeatAnimate()
    {
        player.transform.GetChild(0).GetComponent<Animator>().SetBool("Defeat", true);
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
            Question question = modules[i].GetComponent<Question>();
            question.title.GetComponent<TMPro.TextMeshPro>().text = questions[i].question;
            question.answer1.GetComponent<TMPro.TextMeshPro>().text = questions[i].answer1;
            question.answer2.GetComponent<TMPro.TextMeshPro>().text = questions[i].answer2;
            question.id = questions[i].id;
            question.rightAnswer = questions[i].rightAnswer;
        }
    }

    IEnumerator Score()
    {
        streakCounter = 0;
        bool isStreak = false;
        int wAnswers = 0;
        int score = 0;
        int success = 0;
        int streak = 0;
        int qCheck = 0;
        yield return new WaitForSeconds(Time.deltaTime);
        for (int i = 0; i < modules.Count; i++)
        {       

            if (modules[i].GetComponent<Question>().answered)
            {
                qCheck += 1;
                if (!isStreak)
                {
                    streakCounter = 0;
                }
                if (modules[i].GetComponent<Question>().isChoseCorrect)
                {
                    isStreak = true;
                    streakCounter += 1;
                    success += 1;    
                                   
                }
                else
                {
                    wAnswers += 1;
                    isStreak = false;
                }
                if (streakCounter == 4)
                {
                    streak += 1;
                    streakCounter = 0;
                }
            }
        }
        questionCheck = qCheck;
        wrongAnswers = wAnswers;
        score = success * 30;
        bonusScore = streak * 15;
        this.successes = success;
        this.scoring = score;
        this.rate = streak;
        gameInfoInf.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text =
            "RACHA DE ACIERTOS: " + rate;
        gameInfoInf.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text =
            "ACIERTOS: " + successes;
        gameInfoSup.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text =
            "PUNTAJE: " + scoring;
    }

    public void GameOver()
    {
        gameInfoSup.SetActive(false);
        gameInfoInf.SetActive(false);
        gameOverCanvas.transform.GetChild(1).gameObject.GetComponent<TMP_Text>().text =
            "PUNTAJE: " + scoring;
        gameOverCanvas.transform.GetChild(2).gameObject.GetComponent<TMP_Text>().text =
            "BONUS: " + bonusScore;
        FinalScoring = (scoring + bonusScore);
        gameOverCanvas.transform.GetChild(3).gameObject.GetComponent<TMP_Text>().text =
            "TOTAL: " + FinalScoring;
        carreraDB.updateScore(FinalScoring);//agregamos el update en la base de datos
        int pieces = (FinalScoring) / 135;
        this.GetComponent<DBManagement>().QuerySetRunnerLevel();
        this.GetComponent<DBManagement>().QuerySetPieces(pieces);
        gameOverCanvas.SetActive(true);
        playing = false;
        
    }

    public void ReloadGame()
    {
        successes = 0;
        scoring = 0;
        bonusScore = 0;
        rate = 0;
        questionCheck = 0;
        wrongAnswers = 0;
        streakCounter = 0;
        FinalScoring = 0;
        playing = true;
        instructions.SetActive(true);
        gameInfoInf.SetActive(false);
        gameInfoSup.SetActive(false);
        questionsParent.gameObject.SetActive(false);
        gameOverCanvas.SetActive(false);
        player.transform.GetChild(0).GetComponent<Animator>().SetBool("Defeat", false);
        player.transform.GetChild(0).GetComponent<Animator>().SetBool("Victory", false);
        player.transform.position = new Vector3(63.9f, 0.2818546f, 34.5f);
        player.transform.rotation = Quaternion.Euler(0, -90, 0);
        this.GetComponent<RunnerController>().StopSpawn();

        modules.Clear();
        for (int i = 0; i < questionsParent.childCount; ++i)
            Destroy(questionsParent.GetChild(i).gameObject);
        Start();
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
        gameInfoInf.transform.GetChild(5).gameObject.GetComponent<Button>().image.sprite =
            pauseSprites[0];
        pauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        gameisPaused = false;
        playing = true;
    }

    void Pause()
    {
        gameInfoInf.transform.GetChild(5).gameObject.GetComponent<Button>().image.sprite =
            pauseSprites[1];
        pauseCanvas.SetActive(true);
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
        questionDAO = new QuestionDAO;
        questionDAO.save();
        QuestionInfo[] questions = QuestionDAO.Read();
        return questions;
        /*string path = "Assets/Data/correr.txt";
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
        return data;*/
    }
}
