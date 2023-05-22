using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{
    public GameObject star;
    public Vector3 lift = new Vector3(0, 0.1f, 0);
    bool trigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            trigger = true;
            Destroy(star, 2);

            other.GetComponent<Stars>().PlusStar();
        }
    }

    private void FixedUpdate()
    {
        if(trigger)
        {
            transform.position += lift;
        }
    }
}
