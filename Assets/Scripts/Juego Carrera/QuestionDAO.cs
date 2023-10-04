using System.Net.Mime;
using System.Net;
using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class QuestionDAO
{

    public QuestionInfo[] read(){
        string path = Path.Combine(Application.persistentDataPath, "correr.data");
        string text = File.ReadAllText(path);
        QuestionArray questionArray = JsonUtility.FromJson<QuestionArray>(text);
        QuestionInfo[] questions = questionArray.questions;
        return questions;
    }

    public void Save(){
        string questionsJson = @"{
        ""questions"":
            [
                {
                    ""level"": 1,
                    ""id"": 101,
                    ""question"": ""¿La acreditación es necesaria para que una institución siga funcionando?"",
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
                    ""question"": ""¿La acreditación es válida nacional e internacional?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 107,
                    ""question"": ""¿El registro calificado es obligatorio?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 108,
                    ""question"": ""¿El CNA es el Consejo Nombrado para Asesoría de Acreditación"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 109,
                    ""question"": ""¿Los pares académicos deben visitar la instutucion educativa?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 110,
                    ""question"": ""¿el SNA es el Sistema Nacional de Acreditación?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 111,
                    ""question"": ""¿Es importante para un estudiante, que su programa este Acreditado?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 112,
                    ""question"": ""¿Debo estudiar en un programa sin registro calificado?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 113,
                    ""question"": ""¿Pienso estudiar mi posgrado en el exterior, mi programa debe tener acreditación?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 114,
                    ""question"": ""¿La autoevaluación es un proceso de medición y reflexión sobre la calidad?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 115,
                    ""question"": ""¿la autoevaluación identifica fortalezas y debilidades?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 116,
                    ""question"": ""¿La autoevaluación es necesaria para la acreditación?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 117,
                    ""question"": ""¿En la autoevaluación se revisa los espacios físicos?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 1,
                    ""id"": 118,
                    ""question"": ""¿En la autoevaluación se revisa los espacios deportivos?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 2,
                    ""id"": 201,
                    ""question"": ""Condiciones iniciales"",
                    ""answer1"": ""Conjunto de cualidades y requisitos que deben cumplir las instituciones para acreditarse"",
                    ""answer2"": ""Evidencias iniciales del proceso de Autoevaluación""
                },
                {
                    ""level"": 2,
                    ""id"": 202,
                    ""question"": ""Características de evaluación son, según el acuerdo 02 de 2020"",
                    ""answer1"": ""factores y aspectos"",
                    ""answer2"": ""Temas y preguntas""
                },
                {
                    ""level"": 2,
                    ""id"": 203,
                    ""question"": ""Acuerdo base para la evaluación de programas presenciales"",
                    ""answer1"": ""Acuerdo 02 de 2020"",
                    ""answer2"": ""Acuerdo 05 de 2021""
                },
                {
                    ""level"": 2,
                    ""id"": 204,
                    ""question"": ""Acuerdo base para la evaluación de programas virtuales"",
                    ""answer1"": ""Acuerdo 02 de 2020"",
                    ""answer2"": ""Acuerdo 06 de 2021""
                },
                {
                    ""level"": 2,
                    ""id"": 205,
                    ""question"": ""Autoridad Nacional de acreditación"",
                    ""answer1"": ""Consejo Nacional de Acreditación – CNA"",
                    ""answer2"": ""Ministerio de Educación Nacional MINEDU""
                },
                {
                    ""level"": 2,
                    ""id"": 206,
                    ""question"": ""Autoevaluación"",
                    ""answer1"": ""Proceso que permiten a la institución la identificación de fortalezas y aspectos por mejorar"",
                    ""answer2"": ""Proceso que orienta la implementación de planes de mejoramiento.""
                },
                {
                    ""level"": 2,
                    ""id"": 207,
                    ""question"": ""Plan de mejoramiento"",
                    ""answer1"": ""Conjunto de acciones organizadas para abordar las debilidades"",
                    ""answer2"": ""conjunto de resultados de la evaluación""
                },
                {
                    ""level"": 2,
                    ""id"": 208,
                    ""question"": ""¿Por qué acreditar la institución?"",
                    ""answer1"": ""ser coherente con lo que es y se quiere ser"",
                    ""answer2"": ""Para crecer""
                },
                {
                    ""level"": 2,
                    ""id"": 209,
                    ""question"": ""¿la calidad en educación superior, es?"",
                    ""answer1"": ""nivel de correspondencia con lo esperado"",
                    ""answer2"": ""goodwill de la institución""
                },
                {
                    ""level"": 2,
                    ""id"": 210,
                    ""question"": ""La cultura en la que se potencia las óptimas cualidades"",
                    ""answer1"": ""Acuerdo superior 430 de 2014"",
                    ""answer2"": ""Política de calidad""
                },
                {
                    ""level"": 2,
                    ""id"": 211,
                    ""question"": ""¿La calidad se entiende cómo?"",
                    ""answer1"": ""Un camino"",
                    ""answer2"": ""un conjunto de prácticas cotidianas.""
                },
                {
                    ""level"": 2,
                    ""id"": 212,
                    ""question"": ""¿La acreditación?"",
                    ""answer1"": ""Vigilancia del estado"",
                    ""answer2"": ""Compromiso Institucional""
                },
                {
                    ""level"": 2,
                    ""id"": 213,
                    ""question"": ""Institución acreditada por 10 años, implica tener"",
                    ""answer1"": ""60% o más de programas Acreditados"",
                    ""answer2"": ""Autoevaluación Institucional.""
                },
                {
                    ""level"": 2,
                    ""id"": 214,
                    ""question"": ""Para acreditar un programa se requiere tener"",
                    ""answer1"": ""ocho años de continuidad de matrícula"",
                    ""answer2"": ""maestría y doctorado asociado""
                },
                {
                    ""level"": 2,
                    ""id"": 215,
                    ""question"": ""La autoevaluación implica revisar los altos niveles académicos"",
                    ""answer1"": ""Investigativos"",
                    ""answer2"": ""académicos""
                },
                {
                    ""level"": 2,
                    ""id"": 216,
                    ""question"": ""La autoevaluación involucra"",
                    ""answer1"": ""docentes"",
                    ""answer2"": ""empresarios""
                },
                {
                    ""level"": 2,
                    ""id"": 217,
                    ""question"": ""CNA entrega para la autoevaluación"",
                    ""answer1"": ""guías"",
                    ""answer2"": ""lineamientos""
                },
                {
                    ""level"": 2,
                    ""id"": 218,
                    ""question"": ""Como estudiante debo en la autoevaluación"",
                    ""answer1"": ""Responder las encuestas"",
                    ""answer2"": ""leer los documentos.""
                },
                {
                    ""level"": 3,
                    ""id"": 301,
                    ""question"": ""¿En la autoevaluación se revisa los laboratorios?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 302,
                    ""question"": ""¿En la autoevaluación se revisa los procesos administrativos?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 303,
                    ""question"": ""¿En la autoevaluación se revisa los contenidos académicos de los cursos?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 304,
                    ""question"": ""¿En la autoevaluación participan los estudiantes?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 305,
                    ""question"": ""¿La autoevaluación genera un plan de mejoramiento?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 306,
                    ""question"": ""EL MEN es un acreditador internacional"",
                    ""answer1"": ""NO"",
                    ""answer2"": ""SI""
                },
                {
                    ""level"": 3,
                    ""id"": 307,
                    ""question"": ""La autoevaluación debe ser"",
                    ""answer1"": ""Permanente"",
                    ""answer2"": ""Transparente""
                },
                {
                    ""level"": 3,
                    ""id"": 308,
                    ""question"": ""Los pares académicos"",
                    ""answer1"": ""emiten juicio de calidad"",
                    ""answer2"": ""son externos a la institución""
                },
                {
                    ""level"": 3,
                    ""id"": 309,
                    ""question"": ""La socialización y la capacitación las realiza"",
                    ""answer1"": ""EL CNA"",
                    ""answer2"": ""LA institución""
                },
                {
                    ""level"": 3,
                    ""id"": 310,
                    ""question"": ""En la autoevaluación de un programa se reflexiona sobre"",
                    ""answer1"": ""la relación con la industria"",
                    ""answer2"": ""el impacto en la sociedad""
                },
                {
                    ""level"": 3,
                    ""id"": 311,
                    ""question"": ""¿Es importante para un estudiante, que su programa este Acreditado?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 312,
                    ""question"": ""¿Debo estudiar en un programa sin registro calificado?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 313,
                    ""question"": ""¿Pienso estudiar mi posgrado en el exterior, mi programa debe tener acreditación?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 314,
                    ""question"": ""¿La autoevaluación es un proceso de medición y reflexión sobre la calidad?"",
                    ""answer1"": ""SI"",
                    ""answer2"": ""NO""
                },
                {
                    ""level"": 3,
                    ""id"": 315,
                    ""question"": ""La autoevaluación implica revisar los altos niveles académicos"",
                    ""answer1"": ""Investigativos"",
                    ""answer2"": ""académicos""
                },
                {
                    ""level"": 3,
                    ""id"": 316,
                    ""question"": ""La autoevaluación involucra"",
                    ""answer1"": ""docentes"",
                    ""answer2"": ""empresarios""
                },
                {
                    ""level"": 3,
                    ""id"": 317,
                    ""question"": ""CNA entrega para la autoevaluación"",
                    ""answer1"": ""guías"",
                    ""answer2"": ""lineamientos""
                },
                {
                    ""level"": 3,
                    ""id"": 318,
                    ""question"": ""Como estudiante debo en la autoevaluación"",
                    ""answer1"": ""Responder las encuestas"",
                    ""answer2"": ""leer los documentos.""
                }
            ]
        }";

        string path = Path.Combine(Application.persistentDataPath, "correr.data");
        File.WriteAllText(path,questionsJson);
    }

}