using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardDAO : MonoBehaviour
{    
    [ContextMenu("Read")]
    public string[] Read()
    {
        string path = Path.Combine(Application.persistentDataPath, "memoria.txt");
        string[] text = File.ReadAllLines(path);
        Debug.Log(path);
        Debug.Log(text[0]);
        return text;
    }
}
