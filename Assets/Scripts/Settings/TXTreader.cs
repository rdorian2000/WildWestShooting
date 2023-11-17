using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public class TXTreader : MonoBehaviour
{
    private void Start()
    {
        string filePath = Application.dataPath + "/save.txt";
        if (File.Exists(filePath))
        {
            try
            {
                // Fájl beolvasása
                string[] lines = File.ReadAllLines(filePath);

                // Végigmenni a sorokon
                foreach (string line in lines)
                {
                    // Oszlopokra bontás (például a vesszõ karakterrel)
                    string[] columns = line.Split(',');

                    // Most már elérheted az oszlopokat és dolgozhatsz velük
                    foreach (string column in columns)
                    {
                        Debug.Log(column);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("Hiba történt: " + e.Message);
            }
        }
    }
}

    

