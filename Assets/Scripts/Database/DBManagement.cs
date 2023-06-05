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
        CloseConn();
        int limit = 2000;
        if (score >= (limit * 3))
        {
            Mutation(
                "UPDATE Puntajes SET level = 3 WHERE 123 = puntajes.player_id AND game_id = 1"
            );
        }
        else if (score >= limit)
        {
            Mutation(
                "UPDATE Puntajes SET level = 2 WHERE 123 = puntajes.player_id AND game_id = 1"
            );
        }
        else
        {
            Mutation(
                "UPDATE Puntajes SET level = 1 WHERE 123 = puntajes.player_id AND game_id = 1"
            );
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
        if (score >= (limit * 3))
        {
            Mutation(
                "UPDATE Puntajes SET level = 3 WHERE 123 = puntajes.player_id AND game_id = 2"
            );
        }
        else if (score >= limit)
        {
            Mutation(
                "UPDATE Puntajes SET level = 2 WHERE 123 = puntajes.player_id AND game_id = 2"
            );
        }
        else
        {
            Mutation(
                "UPDATE Puntajes SET level = 1 WHERE 123 = puntajes.player_id AND game_id = 2"
            );
        }
    }

    public void CloseConn()
    {
        dbConnection.Close();
    }

    public void QuerySetPieces(int new_available_pieces)
    {
        Mutation(
            "UPDATE Jugadores SET available_pieces = available_pieces + "
                + new_available_pieces
                + " where player_id = 123"
        );
    }

    public void QuerySetPiecesToRemainder(int pieces)
    {
        Mutation("UPDATE Jugadores SET available_pieces = " + pieces + " where player_id = 123");
    }

    public int QueryGetPieces()
    {
        IDataReader reader = QueryMany(
            "SELECT available_pieces FROM jugadores WHERE jugadores.player_id = 123"
        );
        reader.Read();
        return Int32.Parse(reader[0] + "");
    }

    public List<int> QueryGetPaints()
    {
        IDataReader reader = QueryMany(
            "SELECT COUNT(painting_id) FROM Cuadros WHERE Cuadros.pieces_amount = 15"
        );
        reader.Read();
        int count = Int32.Parse(reader[0] + "");
        CloseConn();
        IDataReader paintsReader = QueryMany(
            "SELECT painting_id FROM Cuadros WHERE Cuadros.pieces_amount = 15"
        );
        List<int> paints = new List<int>();
        for (int i = 0; i < count; i++)
        {
            paintsReader.Read();
            paints.Add(Int32.Parse(paintsReader[0] + ""));
        }
        Shuffle(paints);
        return paints;
    }

    public List<int> QueryGetPaintsAvilable()
    {
        IDataReader reader = QueryMany(
            "SELECT COUNT(painting_id) FROM Cuadros_obtenidos"
        );
        reader.Read();
        int count = Int32.Parse(reader[0] + "");
        CloseConn();
        IDataReader paintsReader = QueryMany(
            "SELECT painting_id FROM Cuadros_obtenidos"
        );
        List<int> paints = new List<int>();
        for (int i = 0; i < count; i++)
        {
            paintsReader.Read();
            paints.Add(Int32.Parse(paintsReader[0] + ""));
        }
        Shuffle(paints);
        return paints;
    }


    public void Shuffle(List<int> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void QueryBuyPaint(int id)
    {
        Mutation("UPDATE Cuadros SET pieces_amount = 0 where painting_id = " + id);
        Mutation("INSERT INTO Cuadros_obtenidos (player_id, painting_id) VALUES (123, " + id + ")");
    }
}
