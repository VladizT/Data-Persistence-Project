using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Main : MonoBehaviour
{

    public string namePlayer;
    public int scores = 0;



    public string bestPlayer;
    public int bestScores = 0;

    public static Main s;

    public string path;


    public AllPlayersData playersData;

    private void Awake()
    {

        if (s != null)
        {
            Destroy(gameObject);
            return;
        }

        s = this;
        path = Application.persistentDataPath + "/saveDate.json";

        DontDestroyOnLoad(gameObject);

    }


    public void CalcBestScore()
    {

        int best = 0;

        if( playersData.arrPlayers.Count > 0 )
        {
            foreach (PlayerData player in playersData.arrPlayers)
            {
                if( player.scores > best )
                {
                    
                    bestScores = player.scores;
                    bestPlayer = player.namePlayer;

                    best = player.scores;

                }

            }
        }

    }


    [System.Serializable]
    public class PlayerData
    {
        public string namePlayer;
        public int scores;
    }

    [System.Serializable]
    public class AllPlayersData
    {
        public string currNamePlayer;

        public List<PlayerData> arrPlayers;
    }

    void SavePlayerScores()
    {

        playersData.currNamePlayer = namePlayer;

        if (playersData.arrPlayers.Count == 0)
        {
            playersData.arrPlayers = new List<PlayerData>();
            playersData.arrPlayers.Add(new PlayerData());
            playersData.arrPlayers[0].namePlayer = namePlayer;
            playersData.arrPlayers[0].scores = scores;
        }
        else
        {

            int i = 0;

            foreach (PlayerData player in playersData.arrPlayers)
            {
                if (player.namePlayer.ToLower() == namePlayer.ToLower())
                {
                    player.scores = scores;
                    //playersData.arrPlayers[i].scores = scores;
                    return;
                }

                i++;
            }

            playersData.arrPlayers.Add(new PlayerData());
            playersData.arrPlayers[playersData.arrPlayers.Count-1].namePlayer = namePlayer;
            playersData.arrPlayers[playersData.arrPlayers.Count-1].scores = scores;

        }

    }

    public void SaveGame()
    {

        SavePlayerScores();

        string json = JsonUtility.ToJson(playersData);

        File.WriteAllText(path, json);

    }


    public void LoadGame()
    {

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playersData = JsonUtility.FromJson<AllPlayersData>(json);

            namePlayer = playersData.currNamePlayer;  

        }

    }



}
