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
                // F�jl beolvas�sa
                string[] lines = File.ReadAllLines(filePath);

                // V�gigmenni a sorokon
                foreach (string line in lines)
                {
                    // Oszlopokra bont�s (p�ld�ul a vessz� karakterrel)
                    string[] columns = line.Split(',');

                    // Most m�r el�rheted az oszlopokat �s dolgozhatsz vel�k
                    foreach (string column in columns)
                    {
                        Debug.Log(column);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log("Hiba t�rt�nt: " + e.Message);
            }
        }
    }
}

    

