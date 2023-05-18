using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using TMPro;

public class progreso : MonoBehaviour
{

    public static progreso instance;
    public TextMeshProUGUI puntajeMemoria;
    public TextMeshProUGUI puntajeRunner;
    public TextMeshProUGUI levelMemoria;
    public TextMeshProUGUI levelRunner;
    

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        IDataReader reader = Query("SELECT score, level FROM jugadores, puntajes where jugadores.player_id = puntajes.player_id");        
        reader.Read();
        puntajeMemoria.text = "Puntaje Acumulado: " + reader[0];
        levelMemoria.text = "Nivel: " + reader[1];
        reader.Read();
        puntajeRunner.text = "Puntaje Acumulado: " + reader[0];
        levelRunner.text = "Nivel: " + reader[1];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IDataReader Query(string q){
        string conn_str = "URI=file:"+ Application.dataPath + "/Plugins/game_db.s3db";
        IDbConnection dbConnection = new SqliteConnection(conn_str);

        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = q;
        IDataReader reader = dbCommand.ExecuteReader();
        return reader;
        
        // while (reader.Read())
        // {         
        //     Debug.Log(reader[0]);
        // }
    }
}
