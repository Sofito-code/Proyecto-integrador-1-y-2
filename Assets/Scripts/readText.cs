using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class readText : MonoBehaviour
{
    public Text textElement1;
    public Text textElement2;
    public Text textElement3;
    public Text textElement4;
    public Text textElement5;
    public Text textElement6;
    public Text textElement7;
    public Text textElement8;
    public Text textElement9;
    public Text textElement10;
    public Text textElement11;
    public Text textElement12;
    public Text textElement13;
    public Text textElement14;
    string path = "Assets/Data/memoria.txt";    
    

    void CountPair()
    {
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        string[] text = File.ReadAllLines(path);
        /* Debug.Log(text.Length); */

        textElement1.text = text[1].Split('|')[2];
        textElement2.text = text[1].Split('|')[3];

        textElement3.text = text[2].Split('|')[2];
        textElement4.text = text[2].Split('|')[3];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
