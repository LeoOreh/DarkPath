using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public int stars = 0;
    public GameObject[] starsCanvas;
    public GameObject[] starsComplite;

    public void PlusStar()
    {
        stars++;
        starsCanvas[stars - 1].SetActive(true);
        starsComplite[stars - 1].SetActive(true);
    }
}
