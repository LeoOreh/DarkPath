using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public GameObject stars;
    public GameObject star;
    public Vector3 lift = new Vector3(0, 0.01f, 0);
    Vector3 liftPlus = new Vector3(0, 0.01f, 0);
    bool trigger = false;

    Color appColor = new Color(0, 0, 0, 0.05f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = true;
            Destroy(star, 2);

            stars.GetComponent<Stars>().PlusStar();
            star.GetComponent<Stars>().enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if(trigger)
        {
            lift += liftPlus;
            transform.position += lift;
            GetComponent<MeshRenderer>().material.color -= appColor;
        }
    }
}
