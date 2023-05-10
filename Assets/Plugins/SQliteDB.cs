using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;


public class SQliteDB : MonoBehaviour
{

    //Esto es una pseudo especie de singleton
    public static SQliteDB instance;

    private void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Query("SELECT player_name FROM jugadores");        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Query(string q){
        string conn_str = "URI=file:"+ Application.dataPath + "/Plugins/game_db.s3db";
        IDbConnection dbConnection = new SqliteConnection(conn_str);

        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = q;
        IDataReader reader = dbCommand.ExecuteReader();
        while (reader.Read())
        {         
            Debug.Log(reader[0]);
        }
    }
}
