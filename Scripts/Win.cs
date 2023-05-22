using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject complitle;
    float time;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            complitle.SetActive(true);
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
