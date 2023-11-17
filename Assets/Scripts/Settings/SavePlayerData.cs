using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;

public class SavePlayerData : MonoBehaviour
{
    [System.Serializable]
    public class Player
    {     
        public string playerName;
        public int playerScore;
        public string playerTime;
        public int crosshairIndex;
    }

    [System.Serializable]
    public class Data
    {
        public Player[] players;

        public Data(int numberOfPlayers)
        {
            players = new Player[numberOfPlayers];
        }
    }

    //private SavePlayerData.Player playerData;

    
    // You can start the load process from Start callback
    /*private void Start()
    {
        if (PlayerPrefs.HasKey("crosshair_index"))
        {
            playerData.crosshairIndex = PlayerPrefs.GetInt("crosshair_index");
        }
        if (PlayerPrefs.HasKey("user_name"))
        {
            playerData.playerName = PlayerPrefs.GetString("user_name");
        }     
    }*/
}