using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using static SavePlayerData;

public class OptionsManager : MonoBehaviour
{
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("user_name"))
        {
            Player.playerName = PlayerPrefs.GetString("user_name");
            inputField.text = PlayerPrefs.GetString("user_name");
        }
        else
        {
            ChangeName("", "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", 10);
        }
             
        

    }

    public void ChangeName(string inputName, string validCharachters, int charachterLimit)
    {
        inputField.text = inputName;
        inputField.characterLimit = charachterLimit;
        inputField.onValidateInput = (string text, int charIndex, char addedChar) =>
        {
            return ValidateChar(validCharachters, addedChar);
        };   
        SaveName(inputName);       
    }

    private char ValidateChar(string validCharachters, char addedChar)
    {
        if (validCharachters.IndexOf(addedChar) != -1)
        {
            //Valid
            return addedChar;
        }
        else
        {
            //Invalid
            return '\0';
        }
    }

    public void BackButton()
    {
        if (inputField.text.Length <= 0)
        {
            inputField.text = "Player";
            Player.playerName = "Player";
        }       
    }   

    public void SaveName(string name)
    {
        inputField.text = name;
        Player.playerName = inputField.text;
        PlayerPrefs.SetString("user_name", Player.playerName);
        PlayerPrefs.Save();        
    }

}
