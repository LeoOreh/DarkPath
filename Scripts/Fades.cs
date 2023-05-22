using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fades : MonoBehaviour
{
    public float timer = 0;
    float time;

    Image image;
    public Color stepColor = new Color(0, 0, 0, 0.03f);
    Color nullAlfa = new Color(0, 0, 0, -1);

    bool act = true;

    void Start()
    {
        image = GetComponent<Image>();
        image.color += nullAlfa;

    }

    private void FixedUpdate()
    {
        time += 0.02f;

        if(act && time >= timer)
        {
            image.color += stepColor;
            if (image.color.a >= 1)
                act = false;
        }
    }

}
