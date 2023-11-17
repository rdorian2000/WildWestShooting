using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

// Osztály a JSON adatok tárolására
public class TXTData
{
    public List<TXTPlayer> players { get; set; }
}

public class TXTPlayer
{
    public string playerName { get; set; }
    public int playerScore { get; set; }
    public string playerTime { get; set; }
    public int crosshairIndex { get; set; }
}

public class TXTreader : MonoBehaviour
{
    public void SortAndWriteBackToTXT()
    {
        string fileName = Application.dataPath + "/save.txt";
        string[] lines = File.ReadAllLines(fileName);
        List<TXTData> players = new List<TXTData>();
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                try
                {
                    TXTData player = JsonConvert.DeserializeObject<TXTData>(line);
                    players.Add(player);
                }
                catch (JsonSerializationException ex)
                {
                    Debug.LogError($"JSON deserialization error: {ex.Message}");
                    Debug.LogError($"Faulty JSON: {line}");
                }
            }           
        }
        players = players.OrderByDescending(p => p.players[0].playerScore).ToList();
        File.WriteAllText(fileName, ""); 
        foreach (TXTData player in players)
        {
            string json = JsonConvert.SerializeObject(player);
            File.AppendAllText(fileName, json + Environment.NewLine);
        }
        TrimFileLines();
    }
    
    //Trim File to 10 lines.
    public void TrimFileLines()
    {     
        string fileName = Application.dataPath + "/save.txt";
        string[] lines = File.ReadAllLines(fileName);
        if (lines.Length > 10)
        {
            List<string> trimmedLines = lines.Take(10).ToList();
            File.WriteAllLines(fileName, trimmedLines);
        }
    }
}



