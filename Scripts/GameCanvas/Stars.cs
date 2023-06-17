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

    public GameObject starObject;
    bool appearStar = false;
    bool appearStarMinus = false;
    Color appColor = new Color(0, 0, 0, 0.05f);
    private void OnTriggerEnter(Collider other)
    {
        appearStar = true;
        appearStarMinus = false;
    }
    private void OnTriggerExit(Collider other)
    {
        appearStarMinus = true;
        appearStar = false;
    }
    private void FixedUpdate()
    {
        if (appearStar && starObject.GetComponent<MeshRenderer>().material.color.a<1)
        {
            starObject.GetComponent<MeshRenderer>().material.color += appColor;
        }
        if (appearStarMinus && starObject.GetComponent<MeshRenderer>().material.color.a > 0)
        {
            starObject.GetComponent<MeshRenderer>().material.color -= appColor;
        }
    }
}
