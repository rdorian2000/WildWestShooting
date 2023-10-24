using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTheLeaderboard : MonoBehaviour
{
    [System.Serializable]
    public class LeaderBoardData
    {
        public string name;
        public int score;
        public Time time;
        public string date;
    }

    [System.Serializable]
    public class Data
    {
        public LeaderBoardData[] players;
    }

    private const string REGISTRY_KEY_SAVING = "REGISTRY_KEY_SAVING";

    public Data datas;

    // Creating JSON from Data and saving it to registry
    public void saveTheGame()
    {
        PlayerPrefs.SetString(REGISTRY_KEY_SAVING, JsonUtility.ToJson(datas));
    }

    // If there is Saved Json in the registry load it and override datas property
    public void loadTheGame()
    {
        if (PlayerPrefs.HasKey(REGISTRY_KEY_SAVING))
        {
            datas = JsonUtility.FromJson<Data>(PlayerPrefs.GetString(REGISTRY_KEY_SAVING));
        }
    }
}
