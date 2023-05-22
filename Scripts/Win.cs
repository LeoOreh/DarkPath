using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    GameObject complitle;
    float time;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        complitle = GameObject.FindGameObjectWithTag("CanvasComplitle");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            complitle.GetComponent<TimeComplite>().start();
            player.GetComponent<PlayerJoystick>().enabled = false;
            complitle.GetComponent<TimeComplite>().timeGame = time;
            player.GetComponent<SaveInfo>().ComplitedLVL();
        }
    }

    private void FixedUpdate()
    {
        time += 0.02f;
    }

}
