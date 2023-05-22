using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveInfo : MonoBehaviour
{
    public int thisLVL;
    int intToSaveLVL;
    int intLoadLVL;

    public void ComplitedLVL()
    {
        ThisLevel();
        LoadGCompletedLevels(thisLVL/100);
        if (thisLVL >= intLoadLVL)
        {
            intToSaveLVL = thisLVL;
            SaveCompletedLevels();
        }
        SaveTheTakenStars();
    }
   void LoadGCompletedLevels(int lvl)
    {
        if (PlayerPrefs.HasKey("CompletedLevels" + lvl))
        {
            intLoadLVL = PlayerPrefs.GetInt("CompletedLevels" +lvl);
            print("Load int CompletedLevels: " + intLoadLVL);
        }
    }

    void SaveCompletedLevels()
    {
        PlayerPrefs.SetInt("CompletedLevels" + (thisLVL/100), intToSaveLVL);
        PlayerPrefs.Save();
        print("Save int CompletedLevels: " + intToSaveLVL);
    }

    void ThisLevel()
    {
        string levelName = SceneManager.GetActiveScene().name;
        string number = levelName.Substring(5);
        thisLVL = int.Parse(number);
        print("this level:  " + thisLVL);
    }

    int stars;
    public void SaveTheTakenStars()
    {
        ThisLevel();
        LoadTheTakeStars();
        stars = GameObject.FindGameObjectWithTag("Player").GetComponent<Stars>().stars;
        if (stars > loadStars)
        {
            string nameSaved = "TakeStarsLevel" + thisLVL;
            PlayerPrefs.SetInt(nameSaved, stars);
            PlayerPrefs.Save();
            print(nameSaved + " : " + stars);
        }

        // Create Save DataBase

        /*
         * LoadGCompletedLevels();  // завершенных уровней
         * 
         * cycle
         * 
         */

    }
    int loadStars;
    public void LoadTheTakeStars()
    {
        loadStars = PlayerPrefs.GetInt("TakeStarsLevel"+ thisLVL);
    }
}
