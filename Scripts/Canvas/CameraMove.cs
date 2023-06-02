using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    GameObject player;
    Vector3 vector;

    public float smoothness = 0.1f;
    public float height_Y = 5;
    public float Z = -2;

    GameObject blackBackground;
    Color minusColor = new Color(0, 0, 0, 0.02f);

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        blackBackground = GameObject.FindGameObjectWithTag("BlackBackground");

        vector = new Vector3(0, height_Y, Z);

        blackBackground.GetComponent<Image>().color = Color.black;
    }
    private void FixedUpdate()
    {
        if (blackBackground.GetComponent<Image>().color.a > 0)
            blackBackground.GetComponent<Image>().color -= minusColor;
        else blackBackground.SetActive(false);

        gameObject.transform.position = Vector3.Lerp (gameObject.transform.position, player.transform.position + vector, smoothness);
    }
}
