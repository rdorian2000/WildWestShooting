using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//Class for the JSON datas.
public class RecordsData
{
    public List<RecordsPlayer> players { get; set; }
}
//Class for one player datas.
public class RecordsPlayer
{
    public string playerName { get; set; }
    public int playerScore { get; set; }
    public string playerTime { get; set; }
    public int crosshairIndex { get; set; }
}

public class RecordsManager : MonoBehaviour
{
    public GameObject HighScoreElementPrefab;
    public GameObject HighScoreElementParent;
    public int positionNumber;
    private void Start()
    {
        positionNumber = 1;
        ReadTheRecords();      
    }
    //This reads the records from the file and displays them on the user interface.
    public void ReadTheRecords()
    {
        string fileName = Application.dataPath + "/save.txt";
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                try
                {
                    RecordsData data = JsonConvert.DeserializeObject<RecordsData>(line);

                    foreach (RecordsPlayer player in data.players)
                    {
                        GameObject highScoreElement = Instantiate(HighScoreElementPrefab, HighScoreElementParent.transform);

                        highScoreElement.transform.Find("Position_Text").GetComponent<TMP_Text>().text = positionNumber.ToString();
                        highScoreElement.transform.Find("Name_Text").GetComponent<TMP_Text>().text = player.playerName;
                        highScoreElement.transform.Find("Score_Text").GetComponent<TMP_Text>().text = player.playerScore.ToString();
                        highScoreElement.transform.Find("Time_Text").GetComponent<TMP_Text>().text = player.playerTime;
                        positionNumber++;                      
                    }
                }
                catch (JsonSerializationException ex)
                {
                    Debug.LogError($"JSON deserialization error: {ex.Message}");
                    Debug.LogError($"Faulty JSON: {line}");
                }
            }
        }
    }
}