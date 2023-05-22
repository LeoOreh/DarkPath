using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public int stars = 0;
    public GameObject[] starsCanvas;

    GameObject complitle;
    private void Start()
    {
        complitle = GameObject.FindGameObjectWithTag("CanvasComplitle");
    }
    public void PlusStar()
    {
        stars++;
        starsCanvas[stars - 1].SetActive(true);
        complitle.GetComponent<TimeComplite>().starsCount = stars; 
    }
}
