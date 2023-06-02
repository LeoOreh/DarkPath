using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ActiveLevels : MonoBehaviour
{
    public bool lockThisLevel;
    public Image imageLock;
    Image newLock;

    public void Lock()
    {
        if (lockThisLevel)
        {
            newLock = Instantiate(imageLock, gameObject.transform);
            newLock.transform.position = gameObject.transform.position;
            GetComponent<Button>().enabled = false;
        }
    }

    public GameObject[] starsActive;
    int loadStars;
    int level;
    public void StarsActive()
    {
        // Load stars
        Int32.TryParse (GetComponentInChildren<Text>().text, out int level);
        int levels = Int32.Parse(SceneManager.GetActiveScene().name.Remove(0, 6));
        int lvl = (levels * 100) + level;
        string nameSaved = "TakeStarsLevel" + lvl;

        if (PlayerPrefs.HasKey(nameSaved))
           loadStars = PlayerPrefs.GetInt(nameSaved, loadStars);

        print("Load stars in level " + lvl + " : " + loadStars);

        for (int i = 0; i < loadStars; i++)
        {
            starsActive[i].SetActive(true);
        }

    }
}
