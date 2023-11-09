using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerData : MonoBehaviour
{
    
    [System.Serializable]
    public class Player
    {     
        public static string playerName;
        public int playerScore;
        public string playerTime;
        public static DateTime actualDate = DateTime.Now;   
        public static int crosshairIndex;
    }


    [System.Serializable]
    public class Data
    {
        public Player[] players;
    }
    private const string REGISTRY_KEY_SAVING = "REGISTRY_KEY_SAVING";

    public Data datas;

    // Creating JSON from Data and saving it to registry
    public void Save()
    {
        PlayerPrefs.SetString(REGISTRY_KEY_SAVING, JsonUtility.ToJson(datas));
    }

    // If there is Saved Json in the registry load it and override datas property
    public void Load()
    {
        if (PlayerPrefs.HasKey(REGISTRY_KEY_SAVING))
        {
            datas = JsonUtility.FromJson<Data>(PlayerPrefs.GetString(REGISTRY_KEY_SAVING));
        }
    }

    // You can start the load process from Start callback
    private void Start()
    {
        Load();

        if (PlayerPrefs.HasKey("crosshair_index"))
        {
            Player.crosshairIndex = PlayerPrefs.GetInt("crosshair_index");
        }

        if (PlayerPrefs.HasKey("user_name"))
        {
            Player.playerName = PlayerPrefs.GetString("user_name");
        }           
        
    }    
}