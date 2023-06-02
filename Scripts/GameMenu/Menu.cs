using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject deleteBackground;
    Color minusColor = new Color(0, 0, 0, 0.01f);

    string buttonStringLevels;
    public GameObject allButtons;
    Vector3 minusVector = new Vector3(1, 0, 0);

    bool clickButton = false;
    float timer = 0;

    private void FixedUpdate()
    {
        if(deleteBackground.GetComponent<Image>().color.a > 0)
            deleteBackground.GetComponent<Image>().color -= minusColor;

        if (clickButton)
            CLICK();            
    }

    void CLICK()
    {
        minusVector = minusVector * 2;
        allButtons.transform.position -= minusVector;
        timer += 0.02f;
        if (timer > 0.3f)
            SceneManager.LoadScene(buttonStringLevels);
    }
    public void ButtonSea()
    {
        allButtons.GetComponent<Animator>().enabled = false;
        clickButton = true;
        buttonStringLevels = "levels1";

    }
    public void ButtonMagma()
    {
        allButtons.GetComponent<Animator>().enabled = false;
        clickButton = true;
        buttonStringLevels = "levels2";
    }
    public void ButtonRiver()
    {
        allButtons.GetComponent<Animator>().enabled = false;
        clickButton = true;
        buttonStringLevels = "levels3";
    }
    public void ButtonSwamp()
    {
        allButtons.GetComponent<Animator>().enabled = false;
        clickButton = true;
        buttonStringLevels = "levels4";
    }
}
