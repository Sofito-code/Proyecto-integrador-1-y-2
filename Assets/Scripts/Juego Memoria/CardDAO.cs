using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CardDAO : MonoBehaviour
{
    [SerializeField]
    public ModelPuntajesArray puntajesArray;

    [SerializeField]
    public ModelJugador jugador;

    public CardInfo[] ReadQuestionJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "memoria.data");
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        CardInfo[] cards = (CardInfo[])bf.Deserialize(fs);
        fs.Close();
        return cards;
    }

    public void SaveQuestionJson()
    {
        string json = @"{
            ""questions"":[
                {
                    ""level"": 1,
                    ""id"": 101,
                    ""question"": ""¿Por qué acreditar la institución?"",
                    ""answer"": ""Ser coherente con lo que es y se quiere ser""
                },
                {
                    ""level"": 1,
                    ""id"": 102,
                    ""question"": ""¿La calidad en educación superior es?"",
                    ""answer"": ""Nivel de correspondencia con lo esperado""
                },
                {
                    ""level"": 1,
                    ""id"": 103,
                    ""question"": ""¿Qué se evalúa en la acreditación?"",
                    ""answer"": ""Los programas, la infraestructura, los recursos, la organización y el funcionamiento""
                },
                {
                    ""level"": 1,
                    ""id"": 104,
                    ""question"": ""¿Qué significa calidad cuando hablamos de educación superior?"",
                    ""answer"": ""El modo como ésta se presta las funciones de docencia, investigación y proyección social""
                },
                {
                    ""level"": 1,
                    ""id"": 105,
                    ""question"": ""¿Es obligatorio el proceso de acreditación?"",
                    ""answer"": ""No. La Ley 30 de 1992 les da a las instituciones de educación superior la libertad de acogerse al Sistema Nacional de Acreditación""
                },
                {
                    ""level"": 1,
                    ""id"": 106,
                    ""question"": ""¿Cuáles son los pasos del proceso para la acreditación?"",
                    ""answer"": ""Realizar la autoevaluación, Visita de pares académicos, informe de autoevaluación y visita, Análisis y toma de decisión, acreditación o no""
                },
                {
                    ""level"": 1,
                    ""id"": 107,
                    ""question"": ""¿Quiénes participan en un proceso de acreditación?"",
                    ""answer"": ""Docentes, estudiantes, empleados, directivas, egresados, empleadores, pares académicos, CNA, MEN""
                },
                {
                    ""level"": 2,
                    ""id"": 201,
                    ""question"": ""¿Quiénes realizan la evaluación para otorgar la acreditación?"",
                    ""answer"": ""Los pares académicos enviados por el CNA quienes son personas de distintas universidades nacionales o internacionales, formados y con capacidad para ello""
                },
                {
                    ""level"": 2,
                    ""id"": 202,
                    ""question"": ""¿Cuál es el estándar que evalúa la pertinencia de los programas académicos en la acreditación?"",
                    ""answer"": ""Pertinencia de la oferta académica.""
                },
                {
                    ""level"": 2,
                    ""id"": 203,
                    ""question"": ""¿Cuál es el estándar que evalúa la gestión académica en la acreditación institucional?"",
                    ""answer"": ""Gestión académica y curricular.""
                },
                {
                    ""level"": 2,
                    ""id"": 204,
                    ""question"": ""¿Cuál es el estándar que evalúa la calidad de los procesos administrativos en la acreditación institucional?"",
                    ""answer"": ""Calidad de la gestión administrativa.""
                },
                {
                    ""level"": 2,
                    ""id"": 205,
                    ""question"": ""¿Qué se evalúa en el estándar de Responsabilidad Fiscal en la acreditación?"",
                    ""answer"": ""La responsabilidad fiscal y financiera de la institución.""
                },
                {
                    ""level"": 2,
                    ""id"": 206,
                    ""question"": ""¿Cuál es el objetivo principal de la acreditación de alta calidad en Colombia?"",
                    ""answer"": ""Fomentar la mejora continua de la calidad de la educación superior.""
                },
                {
                    ""level"": 2,
                    ""id"": 207,
                    ""question"": ""¿La calidad se entiende cómo?"",
                    ""answer"": ""Conjunto de propiedades inherentes a una cosa que permite caracterizarla y valorarla con respecto a las restantes de su especie""
                },
                {
                    ""level"": 3,
                    ""id"": 301,
                    ""question"": ""¿La acreditación es?"",
                    ""answer"": ""El acto por el cual el Estado adopta y hace público el reconocimiento que efectúa una institución sobre la calidad de sus programas académicos""
                },
                {
                    ""level"": 3,
                    ""id"": 302,
                    ""question"": ""¿Las características de evaluación son? según el acuerdo 02 de 2020"",
                    ""answer"": ""factores y aspectos""
                },
                {
                    ""level"": 3,
                    ""id"": 303,
                    ""question"": ""¿En la autoevaluación se revisa los contenidos académicos de los cursos?"",
                    ""answer"": ""Más que contenidos académicos el proceso observa todo el currículo""
                }
            ]
        }";
        CardArray questionArray = JsonUtility.FromJson<CardArray>(json);
        CardInfo[] cards = questionArray.questions;
        string path = Path.Combine(Application.persistentDataPath, "memoria.data");
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, cards);
        fs.Close();
    }

    [ContextMenu("ReadInfo")]
    public void ReadInfo()
    {
        ReadPuntaje();
        ReadJugador();
    }

    private void ReadPuntaje()
    {
        string path = Path.Combine(Application.persistentDataPath, "puntajes.data");
        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            ModelPuntajes[] puntajes = (ModelPuntajes[])bf.Deserialize(fs);
            puntajesArray.puntajes = puntajes;
            fs.Close();
        }
        else
        {
            Debug.Log($"Error: No se pudo leer el puntaje guardado");
            puntajesArray.puntajes[0].score = 0;
        }
    }

    private void ReadJugador()
    {
        string path = Path.Combine(Application.persistentDataPath, "jugador.data");
        if (File.Exists(path))
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            jugador = (ModelJugador) bf.Deserialize(fs);
            fs.Close();
        }
        else
        {
            Debug.Log($"Error: No se pudo leer los datos del jugador");
            jugador.available_pieces = 0;
        }
    }

    public void SaveJugador()
    {
        string path = Path.Combine(Application.persistentDataPath, "jugador.data");
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, jugador);
        fs.Close();
    }

    public void SaveCardLevel()
    {
        int score = puntajesArray.puntajes[0].score;
        int limit = 2000;
        int lvl = 0;
        if (score >= (limit * 3))
        {
            lvl = 3;
        }
        else if (score >= limit)
        {
            lvl = 2;
        }
        else
        {
            lvl = 1;
        }
        puntajesArray.puntajes[0].level = lvl;
        string path = Path.Combine(Application.persistentDataPath, "puntajes.data");
        ModelPuntajes[] puntajes = puntajesArray.puntajes;
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, puntajes);
        fs.Close();
    }
}
