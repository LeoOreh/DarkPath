using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelControl : MonoBehaviour
{
    public GameObject[] levels;
    public int activLvl;
    int loadCompletedLevels = 0;

    private void Start()
    {
        int lev = Int32.Parse(SceneManager.GetActiveScene().name.Remove(0, 6));
        if (PlayerPrefs.HasKey("CompletedLevels" + lev))
        {
            loadCompletedLevels = (PlayerPrefs.GetInt("CompletedLevels" + lev))-(100*lev);
            print("Load int CompletedLevels: " + loadCompletedLevels);
        }
        else print("no found: " + "CompletedLevels" + lev);

        activLvl = loadCompletedLevels + 1;

        for (int i = 0; i < levels.Length; i++)
        {
            if (i >= activLvl)
            {
                levels[i].GetComponent<ActiveLevels>().lockThisLevel = true;
                levels[i].GetComponent<ActiveLevels>().Lock();
            }
            else
            {
                levels[i].GetComponent<ActiveLevels>().StarsActive();
            }
        }
    }
}
