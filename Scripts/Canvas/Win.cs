using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    GameObject complitle;
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
            complitle.GetComponent<TimeComplite>().StartComplitle();
            player.GetComponent<SaveInfo>().ComplitedLVL();
        }
    }
}
