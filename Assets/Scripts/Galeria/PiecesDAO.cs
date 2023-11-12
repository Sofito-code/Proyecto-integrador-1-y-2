using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

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
        FileStream fs = new FileStream(path, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        ModelCuadros[] cuadros = (ModelCuadros[]) bf.Deserialize(fs);
        fs.Close();
        this.cuadrosArray.cuadros = cuadros;
        return cuadros;
    }

    [ContextMenu("SaveCuadros")]
    public void SaveCuadros()
    {
        ModelCuadros[] cuadros = cuadrosArray.cuadros;
        string path = Path.Combine(Application.persistentDataPath, "cuadros.data");
        FileStream fs = new FileStream(path, FileMode.Create);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, cuadros);
        fs.Close();
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
}
