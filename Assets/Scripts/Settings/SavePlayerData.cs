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
}