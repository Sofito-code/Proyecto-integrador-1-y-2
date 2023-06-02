using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;
using TMPro;

public class DBManagement : MonoBehaviour
{
    private string CONN_STR;
    private IDbConnection dbConnection;

    void Awake()
    {
        CONN_STR = "URI=file:" + Application.dataPath + "/Plugins/game_db.s3db";
        dbConnection = new SqliteConnection(CONN_STR);
    }

    public IDataReader QueryMany(string q)
    {
        return DataBaseConn(q);
    }

    public void Mutation(string q)
    {
        DataBaseConn(q);
        CloseConn();
    }

    private IDataReader DataBaseConn(string q)
    {
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = q;
        IDataReader reader = dbCommand.ExecuteReader();
        return reader;
    }

    public string QueryRunnerLevel()
    {
        IDataReader reader = QueryMany(
            "SELECT level FROM jugadores, puntajes WHERE jugadores.player_id = puntajes.player_id AND game_id = 2"
        );
        reader.Read();
        return reader[0] + "";
    }

    public string QueryCardsLevel()
    {
        IDataReader reader = QueryMany(
            "SELECT level FROM jugadores, puntajes WHERE jugadores.player_id = puntajes.player_id AND game_id = 1"
        );
        reader.Read();
        return reader[0] + "";
    }

    public void QuerySetCardsLevel()
    {
        IDataReader reader = QueryMany(
            "SELECT score FROM jugadores, puntajes WHERE jugadores.player_id = puntajes.player_id AND game_id = 1"
        );
        reader.Read();
        int score = Int32.Parse(reader[0] + "");

        int limit = 2000;
        if (score >= (limit*3)) { 
            Mutation("UPDATE Puntajes SET level = 3 WHERE 123 = puntajes.player_id AND game_id = 1");
        }else if(score >= limit){
            Mutation("UPDATE Puntajes SET level = 2 WHERE 123 = puntajes.player_id AND game_id = 1");
        }else{
            Mutation("UPDATE Puntajes SET level = 1 WHERE 123 = puntajes.player_id AND game_id = 1");
        }
    }

    public void QuerySetRunnerLevel()
    {
        IDataReader reader = QueryMany(
            "SELECT score FROM jugadores, puntajes WHERE jugadores.player_id = puntajes.player_id AND game_id = 2"
        );
        reader.Read();
        int score = Int32.Parse(reader[0] + "");
        CloseConn();
        int limit = 1600;
        if (score >= (limit*3)) { 
            Mutation("UPDATE Puntajes SET level = 3 WHERE 123 = puntajes.player_id AND game_id = 2");
        }else if(score >= limit){
            Mutation("UPDATE Puntajes SET level = 2 WHERE 123 = puntajes.player_id AND game_id = 2");
        }else{
            Mutation("UPDATE Puntajes SET level = 1 WHERE 123 = puntajes.player_id AND game_id = 2");
        }
    }

    public void CloseConn()
    {
        dbConnection.Close();
    }
}
