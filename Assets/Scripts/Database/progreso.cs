using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Data;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization.Formatters.Binary;

public class Progreso : MonoBehaviour
{

    public static Progreso instance;
    public TextMeshProUGUI puntajeMemoria;
    public TextMeshProUGUI puntajeRunner;
    public TextMeshProUGUI levelMemoria;
    public TextMeshProUGUI levelRunner;
    [SerializeField]
    public ModelPuntajesArray puntajesArray;

    private void Awake(){
        instance = this;
    }
    void Start()
    {
        ReadPuntaje();
        puntajeMemoria.text = "Puntaje Acumulado: " + puntajesArray.puntajes[0].score;
        levelMemoria.text = "Nivel: " + puntajesArray.puntajes[0].level;
        puntajeRunner.text = "Puntaje Acumulado: " + puntajesArray.puntajes[1].score;
        levelRunner.text = "Nivel: " + puntajesArray.puntajes[1].level;
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
            puntajesArray.puntajes[0].score = 0;
            puntajesArray.puntajes[1].score = 0;
            puntajesArray.puntajes[0].level = 1;
            puntajesArray.puntajes[1].level = 1;
        }
    }
}
