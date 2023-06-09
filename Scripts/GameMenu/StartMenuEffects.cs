using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuEffects : MonoBehaviour
{
    public GameObject blackImage;
    public GameObject imageStart;
    public GameObject backgroundImage;
    public Vector3 vector = new Vector3(0.005f, 0.005f);

    public Color colorDarkStart;
    Color colorDelete = new Color(0, 0, 0, 0.02f);
    public float timeAnimation = 2f;
    public float timeforButton = 3.5f;
    float timer = 0f;


    void Start()
    {
        blackImage.GetComponent<Image>().color = colorDarkStart;

    }
    void FixedUpdate()
    {
        if (blackImage.GetComponent<Image>().color.a > 0)
        {
            colorDarkStart.a -= 0.04f;
            blackImage.GetComponent<Image>().color = colorDarkStart;
        }

        Zoom(imageStart, 1);
        Zoom(backgroundImage, 2);

        timer += 0.02f;
        if (timer > timeAnimation)
        {
            SmoothDeleteImage(imageStart, 3);
            SmoothDeleteImage(backgroundImage, 4);
            Zoom(imageStart, 40);
        }
    }

    void Zoom(GameObject image, int X)
    {
        image.GetComponent<Transform>().transform.localScale += (vector * X);
    }
    void SmoothDeleteImage(GameObject image, int X)
    {
        image.GetComponent<Image>().color -= (colorDelete * X);
    }
}
