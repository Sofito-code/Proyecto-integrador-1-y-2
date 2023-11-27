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
                    ""answer"": ""Ser coherente con lo que es y se quiere ser"",
                    ""topic"": 0
                },
                {
                    ""level"": 1,
                    ""id"": 102,
                    ""question"": ""¿La calidad en educación superior es?"",
                    ""answer"": ""Nivel de correspondencia con lo esperado"",
                    ""topic"": 0
                },
                {
                    ""level"": 1,
                    ""id"": 103,
                    ""question"": ""¿Qué se evalúa en la acreditación?"",
                    ""answer"": ""Los programas, la infraestructura, los recursos, la organización y el funcionamiento"",
                    ""topic"": 1
                },
                {
                    ""level"": 1,
                    ""id"": 104,
                    ""question"": ""¿Qué significa calidad cuando hablamos de educación superior?"",
                    ""answer"": ""El modo como ésta se presta las funciones de docencia, investigación y proyección social"",
                    ""topic"": 1
                },
                {
                    ""level"": 1,
                    ""id"": 105,
                    ""question"": ""¿Es obligatorio el proceso de acreditación?"",
                    ""answer"": ""No. La Ley 30 de 1992 les da a las instituciones de educación superior la libertad de acogerse al Sistema Nacional de Acreditación"",
                    ""topic"": 2
                },
                {
                    ""level"": 1,
                    ""id"": 106,
                    ""question"": ""¿Cuáles son los pasos del proceso para la acreditación?"",
                    ""answer"": ""Realizar la autoevaluación, Visita de pares académicos, informe de autoevaluación y visita, Análisis y toma de decisión, acreditación o no"",
                    ""topic"": 2
                },
                {
                    ""level"": 1,
                    ""id"": 107,
                    ""question"": ""¿Quiénes participan en un proceso de acreditación?"",
                    ""answer"": ""Docentes, estudiantes, empleados, directivas, egresados, empleadores, pares académicos, CNA, MEN"",
                    ""topic"": 3
                },
                {
                    ""level"": 1,
                    ""id"": 108,
                    ""question"": ""La evaluación final la realiza..."",
                    ""answer"": ""El Consejo Nacional de Acreditación"",
                    ""topic"": 3
                },
                {
                    ""level"": 1,
                    ""id"": 109,
                    ""question"": ""La evaluación externa utiliza como punto de partida de..."",
                    ""answer"": ""La autoevaluación"",
                    ""topic"": 4
                },
                {
                    ""level"": 1,
                    ""id"": 110,
                    ""question"": ""Un par evaluador debe ser reconocido por..."",
                    ""answer"": ""La comunidad académica"",
                    ""topic"": 4
                },
                {
                    ""level"": 1,
                    ""id"": 111,
                    ""question"": ""Las características de calidad en el proceso de acreditación se refieren a..."",
                    ""answer"": ""La orientación a un deber ser"",
                    ""topic"": 0
                },
                {
                    ""level"": 2,
                    ""id"": 201,
                    ""question"": ""¿Quiénes realizan la evaluación para otorgar la acreditación?"",
                    ""answer"": ""Los pares académicos enviados por el CNA quienes son personas de distintas universidades nacionales o internacionales, formados y con capacidad para ello"",
                    ""topic"": 0
                },
                {
                    ""level"": 2,
                    ""id"": 202,
                    ""question"": ""¿Cuál es el estándar que evalúa la pertinencia de los programas académicos en la acreditación?"",
                    ""answer"": ""Pertinencia de la oferta académica"",
                    ""topic"": 0
                },
                {
                    ""level"": 2,
                    ""id"": 203,
                    ""question"": ""¿Cuál es el estándar que evalúa la gestión académica en la acreditación institucional?"",
                    ""answer"": ""Gestión académica y curricular"",
                    ""topic"": 1
                },
                {
                    ""level"": 2,
                    ""id"": 204,
                    ""question"": ""¿Cuál es el estándar que evalúa la calidad de los procesos administrativos en la acreditación institucional?"",
                    ""answer"": ""Calidad de la gestión administrativa"",
                    ""topic"": 1
                },
                {
                    ""level"": 2,
                    ""id"": 205,
                    ""question"": ""¿Qué se evalúa en el estándar de Responsabilidad Fiscal en la acreditación?"",
                    ""answer"": ""La responsabilidad fiscal y financiera de la institución"",
                    ""topic"": 2
                },
                {
                    ""level"": 2,
                    ""id"": 206,
                    ""question"": ""¿Cuál es el objetivo principal de la acreditación de alta calidad en Colombia?"",
                    ""answer"": ""Fomentar la mejora continua de la calidad de la educación superior"",
                    ""topic"": 2
                },
                {
                    ""level"": 2,
                    ""id"": 207,
                    ""question"": ""¿La calidad se entiende cómo?"",
                    ""answer"": ""Conjunto de propiedades inherentes a una cosa que permite caracterizarla y valorarla con respecto a las restantes de su especie"",
                    ""topic"": 3
                },
                {
                    ""level"": 2,
                    ""id"": 208,
                    ""question"": ""Dentro de las características de calidad se puede incluir..."",
                    ""answer"": ""El reconocimiento social"",
                    ""topic"": 3
                },
                {
                    ""level"": 2,
                    ""id"": 209,
                    ""question"": ""La cabal realización de un programa puede ser evaluado por..."",
                    ""answer"": ""El desempeño de sus egresados"",
                    ""topic"": 4
                },
                {
                    ""level"": 2,
                    ""id"": 210,
                    ""question"": ""La lectura y juzgamiento de los pares debe partir desde..."",
                    ""answer"": ""Una dimensión universal"",
                    ""topic"": 4
                },
                {
                    ""level"": 2,
                    ""id"": 211,
                    ""question"": ""La evaluación de calidad en campo de la acreditación es compleja por sus indicadores..."",
                    ""answer"": ""Cualitativos y hermenéuticos"",
                    ""topic"": 0
                },
                {
                    ""level"": 3,
                    ""id"": 301,
                    ""question"": ""¿La acreditación es?"",
                    ""answer"": ""El acto por el cual el Estado adopta y hace público el reconocimiento que efectúa una institución sobre la calidad de sus programas académicos"",
                    ""topic"": 0
                },
                {
                    ""level"": 3,
                    ""id"": 302,
                    ""question"": ""¿Las características de evaluación son? según el acuerdo 02 de 2020"",
                    ""answer"": ""Factores y aspectos"",
                    ""topic"": 0
                },
                {
                    ""level"": 3,
                    ""id"": 303,
                    ""question"": ""¿En la autoevaluación se revisa los contenidos académicos de los cursos?"",
                    ""answer"": ""Más que contenidos académicos el proceso observa todo el currículo"",
                    ""topic"": 1
                },
                {
                    ""level"": 3,
                    ""id"": 304,
                    ""question"": ""¿Cúales con los 3 macro procesos deLa UDEA?"",
                    ""answer"": ""Docencia, investigación y extensión"",
                    ""topic"": 1
                },
                {
                    ""level"": 3,
                    ""id"": 305,
                    ""question"": ""¿Cúales son los 3 componentes deLa evaluación?"",
                    ""answer"": ""Autoevaluación, evaluación externa y evaluación final"",
                    ""topic"": 2
                },
                {
                    ""level"": 3,
                    ""id"": 306,
                    ""question"": ""¿Cúal esLa base de la autoevaluación?"",
                    ""answer"": ""Los criterios e indicadores"",
                    ""topic"": 2
                },
                {
                    ""level"": 3,
                    ""id"": 307,
                    ""question"": ""La evaluación externa también se denomina..."",
                    ""answer"": ""Evaluación por pares"",
                    ""topic"": 3
                },
                {
                    ""level"": 3,
                    ""id"": 308,
                    ""question"": ""La evaluación de estándares hace énfasis en..."",
                    ""answer"": ""Insumos y recursos"",
                    ""topic"": 3
                },
                {
                    ""level"": 3,
                    ""id"": 309,
                    ""question"": ""Los estándares de evaluación son condiciones previas que se constituyen en..."",
                    ""answer"": ""El primer renglón de calidad"",
                    ""topic"": 4
                },
                {
                    ""level"": 3,
                    ""id"": 310,
                    ""question"": ""Un plan institucional bien formulado permite pensarLa institución en..."",
                    ""answer"": ""Su dinámica y su historia"",
                    ""topic"": 4
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
