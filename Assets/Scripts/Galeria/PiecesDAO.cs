using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;

public class PiecesDAO : MonoBehaviour
{
    [SerializeField]
    public ModelCuadrosArray cuadrosArray;

    [SerializeField]
    public ModelJugador jugador;

    [ContextMenu("ReadCuadrosJson")]
    public ModelCuadros[] ReadCuadros()
    {
        string path = Path.Combine(Application.persistentDataPath, "cuadros.data");
        string text = File.ReadAllText(path);
        ModelCuadrosArray cuadrosArray = JsonUtility.FromJson<ModelCuadrosArray>(text);
        this.cuadrosArray = cuadrosArray;
        ModelCuadros[] cuadros = cuadrosArray.cuadros;
        return cuadros;
    }

    [ContextMenu("SaveCuadros")]
    public void SaveCuadros()
    {
        string cuadrosJson = JsonUtility.ToJson(cuadrosArray);
        string path = Path.Combine(Application.persistentDataPath, "cuadros.data");
        File.WriteAllText(path, cuadrosJson);
    }

    public void BuyPaint(int id)
    {
        for (int i = 0; i < cuadrosArray.cuadros.Length; i++)
        {
            ModelCuadros paint = cuadrosArray.cuadros[i];
            if (paint.painting_id == id)
            {
                paint.pieces_amount = 0;
                paint.landed = 1;
            }
        }
        SaveCuadros();
    }

    [ContextMenu("ReadJugador")]
    public void ReadJugador()
    {
        string path = Path.Combine(Application.persistentDataPath, "jugador.data");
        if (File.Exists(path))
        {
            string text = File.ReadAllText(path);
            jugador = JsonUtility.FromJson<ModelJugador>(text);
        }
        else
        {
            Debug.Log($"Error: No se pudo leer los datos del jugador");
            jugador.available_pieces = 0;
        }
    }

    public void SaveJugador()
    {
        string jugadorJson = JsonUtility.ToJson(jugador);
        string path = Path.Combine(Application.persistentDataPath, "jugador.data");
        File.WriteAllText(path, jugadorJson);
    }
}
