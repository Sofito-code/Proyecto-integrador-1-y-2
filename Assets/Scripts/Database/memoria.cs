using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class Memoria 
{

    public void updateScore(int newScore){
        Query("UPDATE Puntajes SET score = score + " + newScore + " where player_id = 123 and game_id = 1");
    }

    public void Query(string q){
        string conn_str = "URI=file:"+ Application.dataPath + "/Plugins/game_db.s3db";
        IDbConnection dbConnection = new SqliteConnection(conn_str);

        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = q;
        IDataReader reader = dbCommand.ExecuteReader();        
    }
}
