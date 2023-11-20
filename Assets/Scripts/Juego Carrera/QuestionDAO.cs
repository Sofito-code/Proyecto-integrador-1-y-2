using System.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

public class QuestionDAO : MonoBehaviour
{
    [SerializeField]
    public ModelPuntajesArray puntajesArray;

    [SerializeField]
    public ModelJugador jugador;

    [ContextMenu("SaveQuestionJson")]
    public void SaveQuestionJson()
    {
        string json = @"{
            ""questions"":[
                {
                    ""level"": 1,
                    ""id"": 101,
                    ""question"": ""¿La acreditación institucional es necesaria para que una IES siga funcionando?"",
                    ""answer1"": ""NO"",
                    ""answer2"": ""SI""
                },
                {
                    ""level"": 1,
                    ""id"": 102,
                    ""question"": ""¿El registro calificado es lo mismo que la acreditación?"",
                    ""answer1"": ""NO"",
                    ""answer2"": ""SI""
                },
                {
                    ""level"": 1,
                    ""id"": 103,
                    ""question"": ""¿La acreditación se realiza por institución y por programa académico?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 104,
                    ""question"": ""¿Un programa de posgrado puede acreditarse?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 105,
                    ""question"": ""¿El tiempo por el cual se otorga la acreditación es entre 4 a 10 años?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 106,
                    ""question"": ""¿El registro calificado es obligatorio?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 107,
                    ""question"": ""¿Los pares académicos deben visitar la institución educativa?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 108,
                    ""question"": ""¿El SNA es el Sistema Nacional de Acreditación?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 109,
                    ""question"": ""¿Es importante para un estudiante, que su programa este acreditado?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 110,
                    ""question"": ""¿La autoevaluación es un proceso de medición y reflexión sobre la calidad?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 111,
                    ""question"": ""¿la autoevaluación identifica fortalezas, debilidades y genera un plan de mejora y mantenimiento?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 112,
                    ""question"": ""¿La autoevaluación es necesaria para la acreditación?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 113,
                    ""question"": ""¿En la autoevaluación participan los estudiantes?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 114,
                    ""question"": ""¿La autoevaluación genera un plan de mejoramiento?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 2,
                    ""id"": 201,
                    ""question"": ""¿El MEN es un acreditador internacional?"",
                    ""answer1"": ""NO"",
                    ""answer2"": ""SI""
                },
                {
                    ""level"": 2,
                    ""id"": 202,
                    ""question"": ""¿La autoevaluación es un proceso que termina cuando se solicita al CNA la visita de pares?"",
                    ""answer1"": ""NO"",
                    ""answer2"": ""SI""
                },
                {
                    ""level"": 2,
                    ""id"": 203,
                    ""question"": ""¿En la autoevaluación de un programa se reflexiona sobre la relación con la industria?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 2,
                    ""id"": 204,
                    ""question"": ""En qué proceso se revisa los contenidos académicos de los cursos?"",
                    ""answer1"": ""en la construcción del currículo"",
                    ""answer2"": ""En el proceso de acreditación""
                },
                {
                    ""level"": 2,
                    ""id"": 205,
                    ""question"": ""¿Pienso estudiar mi posgrado en el exterior, mi programa obligatoriamente debe tener acreditación?"",
                    ""answer1"": ""NO"",
                    ""answer2"": ""SI""
                },
                {
                    ""level"": 2,
                    ""id"": 206,
                    ""question"": ""¿Cuál es el requisito mínimo de profesores de tiempo completo en una institución acreditada?"",
                    ""answer1"": ""50%"",
                    ""answer2"": ""30%""
                },
                {
                    ""level"": 2,
                    ""id"": 207,
                    ""question"": ""¿Cuál es el requisito mínimo de graduados de programas de posgrado para la acreditación de una institución?"",
                    ""answer1"": ""un mínimo de 30% de graduados de programas de posgrado."",
                    ""answer2"": ""un mínimo de 50% de graduados de programas de posgrado.""
                },
                {
                    ""level"": 2,
                    ""id"": 208,
                    ""question"": ""¿Cuál es el acuerdo base para la evaluación de programas presenciales?"",
                    ""answer1"": ""Acuerdo 02 de 2020"",
                    ""answer2"": ""Acuerdo superior 430 de 2014""
                },
                {
                    ""level"": 2,
                    ""id"": 209,
                    ""question"": ""¿Cuál es el acuerdo base para la evaluación de programas virtuales?"",
                    ""answer1"": ""Acuerdo 02 de 2020"",
                    ""answer2"": ""Acuerdo superior 430 de 2014""
                },
                {
                    ""level"": 2,
                    ""id"": 210,
                    ""question"": ""¿Cuál es autoridad Nacional de acreditación?"",
                    ""answer1"": ""Consejo Nacional de Acreditación – CNA"",
                    ""answer2"": ""El ministerio de Educación""
                },
                {
                    ""level"": 2,
                    ""id"": 211,
                    ""question"": ""¿La cultura en la que se potencian las óptimas cualidades de un programa académico en la Universidad de Antioquia es?"",
                    ""answer1"": ""Acuerdo superior 430 de 2014"",
                    ""answer2"": ""Acuerdo 02 de 2020""
                },
                {
                    ""level"": 2,
                    ""id"": 212,
                    ""question"": ""¿Cuál es el plazo para presentar el informe de autoevaluación al CNA?"",
                    ""answer1"": ""6 meses antes de la visita de pares evaluadores."",
                    ""answer2"": ""2 meses antes de la visita de pares evaluadores.""
                },
                {
                    ""level"": 2,
                    ""id"": 213,
                    ""question"": ""¿Cuál es el papel de los egresados en el proceso de autoevaluación?"",
                    ""answer1"": ""Proporcionar retroalimentación sobre la formación recibida."",
                    ""answer2"": ""Fomentar la mejora continua de la calidad de la educación superior.""
                },
                {
                    ""level"": 2,
                    ""id"": 214,
                    ""question"": ""¿Cómo mínimo qué porcentaje de programas Acreditados debe tener una IES que opte al periodo de diez años de acreditación?"",
                    ""answer1"": ""60% o más programas Acreditados"",
                    ""answer2"": ""30% o más programas acreditados""
                },
                {
                    ""level"": 3,
                    ""id"": 301,
                    ""question"": ""¿Qué órgano de control es responsable de supervisar el cumplimiento de las políticas de acreditación en Colombia?"",
                    ""answer1"": ""La Superintendencia de Educación."",
                    ""answer2"": ""Consejo Nacional de Acreditación – CNA""
                },
                {
                    ""level"": 3,
                    ""id"": 302,
                    ""question"": ""Pregunta: ¿Cuál es el rol de los estudiantes en el proceso de acreditación?"",
                    ""answer1"": ""Participar en la autoevaluación y proporcionar retroalimentación."",
                    ""answer2"": ""Fomentar la mejora continua de la calidad de la educación superior.""
                },
                {
                    ""level"": 3,
                    ""id"": 303,
                    ""question"": ""¿Cuál es el período mínimo de acreditación que una institución puede obtener en Colombia? Tres años."",
                    ""answer1"": ""Tres años."",
                    ""answer2"": ""Cinco años.""
                },
                {
                    ""level"": 3,
                    ""id"": 304,
                    ""question"": ""¿Cuántos años de continuidad de matrícula se deben tener para acreditar un programa?"",
                    ""answer1"": ""Ocho años de continuidad de matrícula"",
                    ""answer2"": ""Cinco años de continuidad de matrícula.""
                },
                {
                    ""level"": 3,
                    ""id"": 305,
                    ""question"": ""¿Qué es la acreditación institucional?"",
                    ""answer1"": ""un reconocimiento público que da el Estado a la calidad de una institución de educación superior"",
                    ""answer2"": ""es el estándar que evalúa la calidad de los procesos administrativos en la institución""
                },
                {
                    ""level"": 3,
                    ""id"": 306,
                    ""question"": ""¿Qué significa la sigla \""PEI\"" en el contexto de la acreditación institucional?"",
                    ""answer1"": ""Proyecto Educativo Institucional."",
                    ""answer2"": ""Informe de Pares evaluadores""
                },
                {
                    ""level"": 3,
                    ""id"": 307,
                    ""question"": ""¿Qué significa la sigla CNA?"",
                    ""answer1"": ""Consejo Nacional de Acreditación"",
                    ""answer2"": ""Centro Nacional de Aprendizaje.""
                },
                {
                    ""level"": 3,
                    ""id"": 308,
                    ""question"": "": ¿Cuál es el plazo máximo para que una institución corrija las debilidades identificadas durante el proceso de acreditación?"",
                    ""answer1"": ""Dos años, con la posibilidad de una extensión de un año."",
                    ""answer2"": ""Tres años, con la posibilidad de una extensión de un año.""
                },
                {
                    ""level"": 3,
                    ""id"": 309,
                    ""question"": ""¿Cuál es el nivel más alto de acreditación que una institución puede obtener?"",
                    ""answer1"": ""Acreditación de Alta Calidad."",
                    ""answer2"": ""Acreditación Gubernamental de Excelencia Educativa""
                },
                {
                    ""level"": 3,
                    ""id"": 310,
                    ""question"": ""¿Qué significa la sigla SNIES en el contexto de la educación superior en Colombia?"",
                    ""answer1"": ""Sistema Nacional de Información de Educación Superior."",
                    ""answer2"": ""Sistema Nacional de Integración y Evaluación de Servicios.""
                },
                {
                    ""level"": 3,
                    ""id"": 311,
                    ""question"": ""¿Qué tipo de acreditación se otorga a una institución que no cumple con los estándares mínimos de calidad?"",
                    ""answer1"": ""No se otorga la acreditación."",
                    ""answer2"": ""Evaluación de Desvinculación por Estándares Insuficientes.""
                },
                {
                    ""level"": 3,
                    ""id"": 312,
                    ""question"": ""¿Cuál es el término utilizado para describir el proceso de revisión de la autoevaluación por parte del CNA?"",
                    ""answer1"": ""Visita de Pares Evaluadores"",
                    ""answer2"": ""Inspección Autónoma de Evaluadores Externos""
                },
                {
                    ""level"": 3,
                    ""id"": 313,
                    ""question"": ""¿Cuál es el plazo máximo para que el CNA emita la resolución de acreditación después de recibir el \""Informe de Pares Evaluadores"",
                    ""answer1"": ""30 días."",
                    ""answer2"": ""60 días.""
                },
                {
                    ""level"": 3,
                    ""id"": 314,
                    ""question"": ""¿Un plan de mejoramiento es?"",
                    ""answer1"": ""Conjunto de acciones organizadas para abordar las debilidades"",
                    ""answer2"": ""Conjunto de tácticas para destacar debilidades identificadas.""
                }
            ]
        }";
        QuestionArray questionArray = JsonUtility.FromJson<QuestionArray>(json);
        questionArray.ListShuffle();
        QuestionInfo[] questions = questionArray.questions;
        string path = Path.Combine(Application.persistentDataPath, "correr.data");
        FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, questions);
        fs.Close();
    }

    [ContextMenu("ReadQuestionJson")]
    public QuestionInfo[] ReadQuestionJson()
    {
        string path = Path.Combine(Application.persistentDataPath, "correr.data");
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        QuestionInfo[] questions = (QuestionInfo[]) bf.Deserialize(fs);
        fs.Close();
        foreach(QuestionInfo item in questions){
            item.Shuffle();
        }
        return questions;
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
            ModelPuntajes[] puntajes = (ModelPuntajes[]) bf.Deserialize(fs);
            puntajesArray.puntajes = puntajes;
            fs.Close();
        }
        else
        {
            Debug.Log($"Error: No se pudo leer el puntaje guardado");
            puntajesArray.puntajes[1].score = 0;
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

    public void SaveRunnerLevel()
    {
        int score = puntajesArray.puntajes[1].score;
        int limit = 1600;
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
        puntajesArray.puntajes[1].level = lvl;
        string path = Path.Combine(Application.persistentDataPath, "puntajes.data");
        ModelPuntajes[] puntajes = puntajesArray.puntajes;
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, puntajes);
        fs.Close();
    }
}
