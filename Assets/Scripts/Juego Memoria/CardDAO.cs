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
        return text;
    }

    [ContextMenu("GetCards")]
    public CardInfo[] GetCards()
    {
        string[] text = Read();
        CardInfo[] cards = new CardInfo[text.Length];
        for (int i = 0; i < text.Length; i++)
        {
            string[] line = text[i].Split('|');
            cards[i] = new CardInfo(line[0], line[1], line[2], line[3], int.Parse(line[4]));
        }
        return cards;
    }
}
