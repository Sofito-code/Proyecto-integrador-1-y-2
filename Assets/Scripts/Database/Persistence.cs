using System.Net;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Persistence : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { 
        InitPersistence();
    }

    // Update is called once per frame
    void Update() { }

    [ContextMenu("Persistencia")]
    public void InitPersistence()
    {
        InitCuadros();
        InitJugador();
        InitPuntajes();
    }

    private void InitJugador()
    {
        string jugadorJson =
            @"
            {
                ""player_id"": 1,
                ""player_name"": ""Camilo"",			
                ""available_pieces"": 0                
            }";
        string path = Path.Combine(Application.persistentDataPath, "jugador.data");
        if (!File.Exists(path))
            File.WriteAllText(path, jugadorJson);
    }

    private void InitCuadros()
    {
        string cuadrosJson = @"{
        ""cuadros"":
        [
            {
                ""painting_id"": 1,
                ""img_src"": ""Assets/Game/Postales/1.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 2,
                ""img_src"": ""Assets/Game/Postales/2.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 3,
                ""img_src"": ""Assets/Game/Postales/3.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 4,
                ""img_src"": ""Assets/Game/Postales/4.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 5,
                ""img_src"": ""Assets/Game/Postales/5.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 6,
                ""img_src"": ""Assets/Game/Postales/6.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 7,
                ""img_src"": ""Assets/Game/Postales/7.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 8,
                ""img_src"": ""Assets/Game/Postales/8.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 9,
                ""img_src"": ""Assets/Game/Postales/9.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 10,
                ""img_src"": ""Assets/Game/Postales/10.JPG"",
                ""pieces_amount"": 15,
                ""landed"": 0
            },
            {
                ""painting_id"": 11,
                ""img_src"": ""Final"",
                ""pieces_amount"": 15,
                ""landed"": 0
            }
        ]
    }";
        string path = Path.Combine(Application.persistentDataPath, "cuadros.data");
        if (!File.Exists(path))
            File.WriteAllText(path, cuadrosJson);
    }

    private void InitPuntajes()
    {
        string puntajesJson =
            @"
        {
            ""puntajes"":
            [
                {
                    ""game_name"": ""Memoria"",
                    ""score"": 0,
                    ""level"": 1,
                    ""maxLevel"" : 3
                },
                {
                    ""game_name"": ""Carrera"",
                    ""score"": 0,
                    ""level"": 1,
                    ""maxLevel"" : 3
                }
            ]
        }";
        string path = Path.Combine(Application.persistentDataPath, "puntajes.data");
        if (!File.Exists(path))
            File.WriteAllText(path, puntajesJson);
    }
}
