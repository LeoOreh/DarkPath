using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public GameObject barrier;
    public float timer = 0.1f;
    bool press = false;
    float y;
    Vector3 vector = Vector3.zero;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            press = true;
            y = barrier.transform.position.y;
        }
    }
    private void FixedUpdate()
    {
        if(press)
        {
            y = Mathf.Lerp(y, 0, timer);
            vector = new Vector3(barrier.transform.position.x, y, barrier.transform.position.z);
            barrier.transform.position = vector;

            if(barrier.transform.position.y <=0)
            {
                press = false;
                gameObject.SetActive(false);
            }
        }
    }
}
