using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{



    public GameObject window;
    public GameObject close;
    public GameObject play;
    public void ButtonOpenSettings()
    {
        close.SetActive(true);
        window.SetActive(true);
        play.SetActive(false);
    }
    public void ButtonCloseWindow()
    {
        window.SetActive(false);
        close.SetActive(false);
        play.SetActive(true);
    }
    public void JoystickSet1()
    {
        PlayerPrefs.SetInt("ControlSettings", 1);
        PlayerPrefs.Save();
        print("Save Control Settings");
    }
    public void ButtonsSet2()
    {
        PlayerPrefs.SetInt("ControlSettings", 2);
        PlayerPrefs.Save();
        print("Save Control Settings");
    }
}
