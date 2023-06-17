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

    public bool colliderTrue = false;

    //-------------------
    public bool brokenGlass;
    public GameObject brokenGlassArray;

    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

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
                original = road.GetComponent<MeshRenderer>().material.color;
            }

            //GetComponent<BoxCollider>().enabled = false;
            colliderTrue = true;

            //---------
            if(brokenGlass)
            brokenGlassArray.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        colliderTrue = false;
    }
    float dist;
    Color colorAlfa = new Color();
    Color original = new Color();
    private void FixedUpdate()
    {
        if (colliderTrue && smoothAppearanceRoad)
        {
            dist = Vector3.Distance(player.transform.position, gameObject.transform.position);
            colorAlfa = original + new Color(0, 0, 0, 1.2f - (dist / 2));
            road.GetComponent<MeshRenderer>().material.color = colorAlfa;
        }
        else road.GetComponent<MeshRenderer>().material.color = new Color();



    }
}
