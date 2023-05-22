using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFall : MonoBehaviour
{
    GameObject player;
    GameObject cam;
    GameObject complitle;

    bool trigg = false;
    float time = 0;

    private void Start()
    {
        complitle = GameObject.FindGameObjectWithTag("CanvasComplitle");
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("MainCamera");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerJoystick>().enabled = false;
            player.GetComponent<SphereCollider>().enabled = false;
            Physics.gravity = new Vector3(0, -30, 0);
            cam.GetComponent<CameraMove>().enabled = false;
            
            //complitle.GetComponent<TimeComplite>().timeGame = time;
            player.GetComponent<SaveInfo>().SaveTheTakenStars();

            trigg = true;
        }
    }
    private void FixedUpdate()
    {
        if (trigg)
        {
            time += 0.02f;

        }

        if (time > 1)
        {
            complitle.GetComponent<TimeComplite>().start();
            gameObject.GetComponent<PlayerFall>().enabled = false;
        }
    }
}
