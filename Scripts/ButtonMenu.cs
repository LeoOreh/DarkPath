using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ButtonMenu : MonoBehaviour
{
    public GameObject deleteBackground;
    Color minusColor = new Color(0, 0, 0, 0.02f);
    bool clickButtolLevel = false;
    string loadLevelString;
    float timer;
    public GameObject blackBackground;
    float x = 1;
    public GameObject buttonPlay;
    private void Start()
    {
        if (gameObject.tag == "MainCamera")
            deleteBackground.SetActive(true);
    }
    private void FixedUpdate()
    {
        if (gameObject.tag == "MainCamera" && deleteBackground.GetComponent<Image>().color.a > 0)
            deleteBackground.GetComponent<Image>().color -= minusColor*2;

        if (clickButtonPlay)
        {
            clickPlayActive -= 0.02f;
            x = x * 2;
            buttonPlay.transform.localPosition = new Vector3(-x, 0, 0);
            if (clickPlayActive < 0 )
            {
                SceneManager.LoadScene(1);
            }
        }
        if (gameObject.tag == "MainCamera" && clickButtolLevel)
        {
            blackBackground.GetComponent<Image>().color += minusColor*3;
            timer += 0.02f;
            if (timer > 0.3f)
                SceneManager.LoadScene(loadLevelString);
        }
    }

    bool clickButtonPlay = false;
    public float clickPlayActive = 0.4f;
    public void ButtonMenuLevels()
    {

        clickButtonPlay = true;
        buttonPlay.GetComponent<Animator>().enabled = false;

    }
    public void ButtonExitInMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    int number;
    public void ButtonLevels()
    {
        number = int.Parse(this.GetComponentInChildren<Text>().text);
        int lev = Int32.Parse (SceneManager.GetActiveScene().name.Remove(0,6));
        lev = (lev * 100) + number;
        print("Open Level: " + lev);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ButtonMenu>().clickButtolLevel = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ButtonMenu>().loadLevelString = "Level" + lev;
        //SceneManager.LoadScene("Level"+lev);
    }

    public void ButtonsRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Decimal lev = (Int32.Parse(SceneManager.GetActiveScene().name.Remove(0, 5)))/100;
        lev = Math.Round(lev);
        SceneManager.LoadScene("levels" + lev);
    }
    public void Next()
    {
        int lev = (Int32.Parse(SceneManager.GetActiveScene().name.Remove(0, 5))) + 1;
        SceneManager.LoadScene("Level" + lev);
    }
}
