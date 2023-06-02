using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    int fps;
    int a;
    int summFPS;
    int amplitude = 10;
    private void Update()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        summFPS += fps;
        a++;
        if (a >= amplitude)
        {
            GetComponent<Text>().text = "" + (summFPS / 10);
            a = 0;
            summFPS = 0;
        }

    }
}
