using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

//Class for the JSON datas.
public class TXTData
{
    public List<TXTPlayer> players { get; set; }
}
//Class for one player datas.
public class TXTPlayer
{
    public string playerName { get; set; }
    public int playerScore { get; set; }
    public string playerTime { get; set; }
    public int crosshairIndex { get; set; }
}

public class TXTReadAndSort : MonoBehaviour
{
    //This reads, sort and write back to txt.
    public void SortAndWriteBackToTXT()
    {
        string fileName = Application.dataPath + "/save.txt";
        string[] lines = File.ReadAllLines(fileName);
        List<TXTData> players = new List<TXTData>();

        //This reads and deserialize the txt.
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
        //This sorts the lines.
        players = players.OrderByDescending(p => p.players[0].playerScore).ToList();
        File.WriteAllText(fileName, ""); 

        //This writes back in the txt.
        foreach (TXTData player in players)
        {
            string json = JsonConvert.SerializeObject(player);
            File.AppendAllText(fileName, json + Environment.NewLine);
        }
        TrimFileLines();
    }
    
    //This trims the file to 8 lines.
    public void TrimFileLines()
    {     
        string fileName = Application.dataPath + "/save.txt";
        string[] lines = File.ReadAllLines(fileName);
        if (lines.Length > 8)
        {
            List<string> trimmedLines = lines.Take(8).ToList();
            File.WriteAllLines(fileName, trimmedLines);
        }
    }
}



