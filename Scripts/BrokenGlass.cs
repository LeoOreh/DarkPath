using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour
{
    public GameObject[] bitGross;

    public GameObject positionParent;
    GameObject player;

    public float distanceBitGlass = 2.0f;
    public float speedMove = 0.1f;

    Quaternion rotationNull = new Quaternion(1, 0, 0, 1);

    float timer;

    public Material[] colorsArray;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        int randomColors = Random.Range(0, colorsArray.Length);

        for (int i = 0; i < bitGross.Length; i++)
        {
            bitGross[i].transform.position = new Vector3(Random.Range(player.transform.position.x - distanceBitGlass, player.transform.position.x + distanceBitGlass), 
                                                          Random.Range(player.transform.position.y - distanceBitGlass, player.transform.position.y + distanceBitGlass), 
                                                          Random.Range(player.transform.position.z - distanceBitGlass, player.transform.position.z + distanceBitGlass));
            bitGross[i].transform.rotation = new Quaternion (Random.Range(0.01f, 1.00f), Random.Range(0.01f, 1.00f), Random.Range(0.01f, 1.00f), 0);

            bitGross[i].GetComponent<MeshRenderer>().material.color = colorsArray[randomColors].color;
        }
    }

    private void FixedUpdate()
    {
        timer += 0.02f;
        if (timer < 1)
        {
            for (int i = 0; i < bitGross.Length; i++)
            {
                bitGross[i].transform.position = Vector3.Lerp(bitGross[i].transform.position, positionParent.transform.position, speedMove);
                bitGross[i].transform.rotation = Quaternion.Lerp(bitGross[i].transform.rotation, rotationNull, speedMove);
            }
        }
    }
}
