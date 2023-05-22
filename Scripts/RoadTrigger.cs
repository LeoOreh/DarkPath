using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    public bool smoothAppearanceRoad;
    public GameObject road;
    public Material[] colors;
    int randomNamber;

    Color colorMinus = new Color(0, 0, 0, -1);
    Color colorPlusBit = new Color(0, 0, 0, 0.1f);

    //-------------------

    bool colliderTrue = false;

    //-------------------
    public bool brokenGlass;
    public GameObject brokenGlassArray;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (smoothAppearanceRoad)
            {
                  road.SetActive(true);
                  randomNamber = Random.Range(0, colors.Length);
                  road.GetComponent<MeshRenderer>().material = colors[randomNamber];
                  road.GetComponent<MeshRenderer>().material.color += colorMinus;
            }

            GetComponent<BoxCollider>().enabled = false;
            colliderTrue = true;

            //---------
            if(brokenGlass)
            brokenGlassArray.SetActive(true);
        }
    }
    private void FixedUpdate()
    {
       if (colliderTrue && smoothAppearanceRoad && road.GetComponent<MeshRenderer>().material.color.a < 1) 
        {
            road.GetComponent<MeshRenderer>().material.color += colorPlusBit;
        }
       else colliderTrue = false;
    }
}
