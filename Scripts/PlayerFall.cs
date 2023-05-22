using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    GameObject player;
    GameObject cam;
    GameObject joystick;
    public GameObject complite;

    float time;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        cam = GameObject.FindGameObjectWithTag("MainCamera");

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<PlayerJoystick>().enabled = false;
            player.GetComponent<SphereCollider>().enabled = false;
            Physics.gravity = new Vector3(0, -30, 0);
            cam.GetComponent<CameraMove>().enabled = false;
            complite.SetActive(true);
            //joystick.SetActive(false);
            complite.GetComponent<TimeComplite>().timeGame = time;

            player.GetComponent<SaveInfo>().SaveTheTakenStars();
        }
    }
    private void FixedUpdate()
    {
        time += 0.02f;
    }
}
