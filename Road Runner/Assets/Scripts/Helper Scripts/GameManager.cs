using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameData gameData;

    [HideInInspector]
    public int star_Score, score_Count, selected_Index;

    [HideInInspector]
    public bool[] heroes;

    [HideInInspector]
    public bool play_Sound = true;

    private string data_Path = "GameData.dat";

    void Awake()
    {
        MakeSingletone();

        InintializeGameDeta();
    }

    void MakeSingletone()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void InintializeGameDeta()
    {
        // test if the game started for the first time
        LoadGameData();

        if (gameData == null)
        {
            // running the game for the first time

            star_Score = 0;
            score_Count = 0;
            selected_Index = 0;

            // set up the heroes array
            heroes = new bool[9];
            heroes[selected_Index] = true;

            // the first hero is the default hero
            for (int i = 1; i < heroes.Length; i++)
            {
                heroes[i] = false;
            }

            gameData = new GameData();
            gameData.StarScore = star_Score;
            gameData.ScoreCount = score_Count;
            gameData.Heroes = heroes;
            gameData.SelectedIndex = selected_Index;

            SaveGameData();
        }
    }

    public void SaveGameData()
    {
        FileStream file = null; // the file where i store the data on the computer

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            // MAKE SURE IT WORKS
            // IF NOT : Unity 2018 changes the path to C:\Users\username\AppData\Local\company\game (on Windows).

            // Create a file name GameData to be save in the application persistent data path
            file = File.Create(Application.persistentDataPath + data_Path);

            if (gameData != null)
            {
                gameData.Heroes = heroes;
                gameData.StarScore = star_Score;
                gameData.ScoreCount = score_Count;
                gameData.SelectedIndex = selected_Index;

                // serialize the game data to the file
                bf.Serialize(file, gameData);
            }

        }
        catch (Exception e)
        {
            // TODO: THROW EXECPTION
        }
        finally
        {
            // close the file to prevent problems like memory leak
            
            if (file != null)
            {
                file.Close();
            }
        }
    }

    void LoadGameData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            // open the game data file
            file = File.Open(Application.persistentDataPath + data_Path, FileMode.Open);

            gameData = (GameData)bf.Deserialize(file);

            if (gameData != null)
            {
                star_Score = gameData.StarScore;
                score_Count = gameData.ScoreCount;
                heroes = gameData.Heroes;
                selected_Index = gameData.SelectedIndex;
            }
        }
        catch (Exception e)
        {
            // TODO: THROW EXECPTION
        }
        finally
        {
            // close the file
            if (file != null)
            {
                file.Close();
            }
        }
    }
}
