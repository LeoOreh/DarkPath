using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeComplite : MonoBehaviour
{
    public float timeGame;
    public Text textTime;

    public int starsCount = 0;
    public GameObject[] stars;

    public GameObject objectForActive;
    public GameObject next;

    public void StartComplitle ()
    {
        objectForActive.SetActive(true);
        textTime.text = (int)timeGame + " sec";

        for (int i = 0; i < starsCount; i++)
        {
            stars[i].SetActive(true);
        }

        int lev = Int32.Parse(SceneManager.GetActiveScene().name.Remove(0, 5));
        int levels = lev /100;
        int complLev = PlayerPrefs.GetInt("CompletedLevels" + levels);
        if (complLev >= lev)
        {
            next.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
        timeGame += 0.02f;
    }
}
