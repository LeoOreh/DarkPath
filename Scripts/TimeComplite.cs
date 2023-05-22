using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeComplite : MonoBehaviour
{
    public float timeGame;
    public Text textTime;

    private void Start()
    {
        textTime.text = (int)timeGame + " sec";
    }
}
