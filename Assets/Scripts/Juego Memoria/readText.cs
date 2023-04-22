using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class readText : MonoBehaviour
{
    public Text[] textElement;
    public Image[] imageElement;
    public string level;

    // Start is called before the first frame update
    void Start()
    {
        
        List<PreguntaYrespuesta> preguntasNivel1 = Levels(level);
        for (int cont = 0; cont < textElement.Length; cont+=2){
            textElement[cont].text = preguntasNivel1[(1+cont)/2].pregunta;
            textElement[cont+1].text = preguntasNivel1[(1+cont)/2].respuesta;
            /* imageElement[cont]    */      
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    List<PreguntaYrespuesta> Levels(string level)
    {       
        PreguntaYrespuesta[] datos = cargarDatos();
        List<PreguntaYrespuesta> levelPyR = new List<PreguntaYrespuesta>();
        foreach (PreguntaYrespuesta item in datos){            
            if(item.dificultad.Equals(level)){
                levelPyR.Add(item);
            }
        }
        return levelPyR;
    }

    PreguntaYrespuesta[] cargarDatos(){
        string path = "Assets/Data/memoria.txt"; 
        string[] text = File.ReadAllLines(path);
        int preguntasTotales = text.Length;
        PreguntaYrespuesta[] datos = new PreguntaYrespuesta[preguntasTotales];
        for (int cont = 0; cont < preguntasTotales; cont++){
            string dificultad = text[cont].Split('|')[0];
            string id = text[cont].Split('|')[1];
            string pregunta = text[cont].Split('|')[2];
            string respuesta = text[cont].Split('|')[3];
            PreguntaYrespuesta PyR = new PreguntaYrespuesta(dificultad,id,pregunta,respuesta);
            datos[cont] = PyR; 
        }
        return datos;
    }
}

class PreguntaYrespuesta
{
    public string dificultad {get;}
    public string id {get;}
    public string pregunta {get;}
    public string respuesta {get;}

    public PreguntaYrespuesta(){}

    public PreguntaYrespuesta(string dificultad, string id, string pregunta, string respuesta)
    {
        this.dificultad = dificultad;
        this.id = id;
        this.pregunta = pregunta;
        this.respuesta = respuesta;
    }    
}
