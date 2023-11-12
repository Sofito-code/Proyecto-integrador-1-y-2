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
        string json =
            @"{
        ""questions"":
            [
                {
                    ""level"": 1,
                    ""id"": 101,
                    ""question"": ""¿Qué es la acreditación institucional?"",
                    ""answer"": ""es un reconocimiento público que da el Estado a la calidad de una institución de educación superior"",
                    ""topic"": 0
                },
                {
                    ""level"": 1,
                    ""id"": 102,
                    ""question"": ""¿Qué se evalúa?"",
                    ""answer"": ""Los programas, la infraestructura, los recursos, la organización el funcionamiento"",
                    ""topic"": 1
                },
                {
                    ""level"": 1,
                    ""id"": 103,
                    ""question"": ""¿Qué significa calidad cuando hablamos de educación superior?"",
                    ""answer"": ""el modo como ésta se presta las funciones de docencia, investigación y proyección social"",
                    ""topic"": 2
                },
                {
                    ""level"": 1,
                    ""id"": 104,
                    ""question"": ""¿Es obligatorio el proceso de acreditación?"",
                    ""answer"": ""La Ley 30 de 1992 le da a las instituciones de educación superior la libertad de acogerse al Sistema Nacional de Acreditación"",
                    ""topic"": 3
                },
                {
                    ""level"": 1,
                    ""id"": 105,
                    ""question"": ""¿Cuáles son los pasos del proceso para la acreditación?"",
                    ""answer"": ""Realizar la autoevaluación, Visita de pares académicos, informe de autoevaluación y visita, Análisis y toma de decisión, acreditación o no"",
                    ""topic"": 4
                },
                {
                    ""level"": 1,
                    ""id"": 106,
                    ""question"": ""¿Quiénes participan en un proceso de acreditación?"",
                    ""answer"": ""estudiantes, empleados, profesores, egresados El CNA y los pares por este designados"",
                    ""topic"": 5
                },
                {
                    ""level"": 1,
                    ""id"": 107,
                    ""question"": ""¿Quiénes realizan la evaluación para otorgar la acreditación?"",
                    ""answer"": ""Los pares son personas de distintas universidades nacionales o internacionales, formados y con capacidad para ello"",
                    ""topic"": 0
                },
                {
                    ""level"": 1,
                    ""id"": 108,
                    ""question"": ""Condiciones iniciales"",
                    ""answer"": ""Conjunto de cualidades y requisitos que deben cumplir las instituciones para acreditarse"",
                    ""topic"": 1
                },
                {
                    ""level"": 1,
                    ""id"": 109,
                    ""question"": ""Características de evaluación son, según el acuerdo 02 de 2020"",
                    ""answer"": ""factores y aspectos"",
                    ""topic"": 2
                },
                {
                    ""level"": 2,
                    ""id"": 201,
                    ""question"": ""Acuerdo base para la evaluación de programas virtuales"",
                    ""answer"": ""Acuerdo 02 de 2020"",
                    ""topic"": 0
                },
                {
                    ""level"": 2,
                    ""id"": 202,
                    ""question"": ""Autoridad Nacional de acreditación"",
                    ""answer"": ""Consejo Nacional de Acreditación – CNA"",
                    ""topic"": 1
                },
                {
                    ""level"": 2,
                    ""id"": 203,
                    ""question"": ""Autoevaluación"",
                    ""answer"": ""Proceso que permiten a la institución la identificación de fortalezas y aspectos por mejorar"",
                    ""topic"": 2
                },
                {
                    ""level"": 2,
                    ""id"": 204,
                    ""question"": ""Plan de mejoramiento"",
                    ""answer"": ""Conjunto de acciones organizadas para abordar las debilidades"",
                    ""topic"": 3
                },
                {
                    ""level"": 2,
                    ""id"": 205,
                    ""question"": ""¿Por qué acreditar la institución?"",
                    ""answer"": ""ser coherente con lo que es y se quiere ser"",
                    ""topic"": 4
                },
                {
                    ""level"": 2,
                    ""id"": 206,
                    ""question"": ""¿la calidad en educación superior, es?"",
                    ""answer"": ""nivel de correspondencia con lo esperado"",
                    ""topic"": 5
                },
                {
                    ""level"": 2,
                    ""id"": 207,
                    ""question"": ""La cultura en la que se potencia las óptimas cualidades"",
                    ""answer"": ""Acuerdo superior 430 de 2014"",
                    ""topic"": 0
                },
                {
                    ""level"": 2,
                    ""id"": 208,
                    ""question"": ""¿La calidad se entiende cómo?"",
                    ""answer"": ""Un camino"",
                    ""topic"": 1
                },
                {
                    ""level"": 2,
                    ""id"": 209,
                    ""question"": ""¿La acreditación?"",
                    ""answer"": ""Vigilancia del estado"",
                    ""topic"": 2
                },
                {
                    ""level"": 2,
                    ""id"": 210,
                    ""question"": ""Acuerdo base para la evaluación de programas presenciales"",
                    ""answer"": ""Acuerdo 02 de 2020"",
                    ""topic"": 3
                },
                {
                    ""level"": 3,
                    ""id"": 301,
                    ""question"": ""Institución acreditada por 10 años, implica tener"",
                    ""answer"": ""60% o más de programas Acreditados"",
                    ""topic"": 0
                },
                {
                    ""level"": 3,
                    ""id"": 302,
                    ""question"": ""Para acreditar un programa se requiere tener"",
                    ""answer"": ""ocho años de continuidad de matrícula"",
                    ""topic"": 1
                },
                {
                    ""level"": 3,
                    ""id"": 303,
                    ""question"": ""La autoevaluación implica revisar los altos niveles académicos"",
                    ""answer"": ""Investigativos"",
                    ""topic"": 2
                },
                {
                    ""level"": 3,
                    ""id"": 304,
                    ""question"": ""La autoevaluación involucra"",
                    ""answer"": ""docentes"",
                    ""topic"": 3
                },
                {
                    ""level"": 3,
                    ""id"": 305,
                    ""question"": ""CNA entrega para la autoevaluación"",
                    ""answer"": ""guías"",
                    ""topic"": 4
                },
                {
                    ""level"": 3,
                    ""id"": 306,
                    ""question"": ""Como estudiante debo en la autoevaluación"",
                    ""answer"": ""Responder las encuestas"",
                    ""topic"": 5
                },
                {
                    ""level"": 3,
                    ""id"": 307,
                    ""question"": ""La autoevaluación debe ser"",
                    ""answer"": ""Permanente"",
                    ""topic"": 0
                },
                {
                    ""level"": 3,
                    ""id"": 308,
                    ""question"": ""Los pares académicos"",
                    ""answer"": ""emiten juicio de calidad"",
                    ""topic"": 1
                },
                {
                    ""level"": 3,
                    ""id"": 309,
                    ""question"": ""La socialización y la capacitación las realiza"",
                    ""answer"": ""EL CNA"",
                    ""topic"": 2
                },
                {
                    ""level"": 3,
                    ""id"": 310,
                    ""question"": ""En la autoevaluación de un programa se reflexiona sobre"",
                    ""answer"": ""la relación con la industria"",
                    ""topic"": 3
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
