using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    private List<QuestionInfo> questions;
    private float[,] coordQuestions = new float[12, 3]
    {
        {30.12f, 40.04f, 0f}, //
        {0f, 40.04f, 0f},
        {-30.12f, 40.04f, 0f},
        {-65.323f, 26.01f, -60.628f},
        {-69.45f, 0f, -90f},
        {-65.323f, -26.01f, -119.372f},
        {-30.12f, -40.04f, 180f},
        {0f, -40.04f, 0f},
        {30.12f, -40.04f, 180f},
        {65.323f, -26.01f, 119.372f},
        {69.45f, 0f, 90f},
        {65.323f, 26.01f, 60.628f}
    };

    public GameObject questionPrefab;
    public Transform questionsParent;    
    public string level;    
    private List<GameObject> modules = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        questions = Levels(level);
        Create();
    }

    // Update is called once per frame
    void Update() { }

    public void Create()
    {
        for (int i = 0; i < 12; i++)
        {
            float x = coordQuestions[i,0];
            float z = coordQuestions[i,1];
            float y = coordQuestions[i,2];
            GameObject questionTemp = Instantiate(
                questionPrefab,
                new Vector3(x, 2, z),
                Quaternion.Euler(new Vector3(0, y, 0))
            );
            modules.Add(questionTemp);
            questionTemp.transform.SetParent(questionsParent);
            questionTemp.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshPro>().text = questions[i].question;
            questionTemp.transform.GetChild(4).gameObject.GetComponent<TMPro.TextMeshPro>().text = questions[i].answer1;
            questionTemp.transform.GetChild(5).gameObject.GetComponent<TMPro.TextMeshPro>().text = questions[i].answer2;
        }
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
