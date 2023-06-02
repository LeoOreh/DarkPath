using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashGlass : MonoBehaviour
{
    public GameObject[] allRoad;
    public float timeBeforeCrash = 5;
    public float timeGapRoad = 1;
    public float timer;
    int indexArray = 0;

    bool colliderStart;
    GameObject[] bitArray;
    GameObject objectRoad;
    Vector3[] rndVector;
    Color minusColor = new Color(0, 0, 0, 0.04f);
    Vector3 minusScale = new Vector3(0.04f, 0.04f, 0.04f);

    public float speedXVector = 0.1f;
    public float speedYVector = 0.1f;
    public float speedZVector = 0.1f;

    private void FixedUpdate()
    {
        if (timeBeforeCrash <= 0)
        {
            timer += 0.02f;
            if (timer >= timeGapRoad)
            {
                if (indexArray < allRoad.Length - 1)
                    indexArray++;
                else GetComponent<CrashGlass>().enabled = false;

                timer = 0;
                rndVector = null;
            }
            else
            {
                if (allRoad[indexArray])
                {
                    if (allRoad[indexArray].GetComponent<RoadTrigger>().brokenGlass == true)
                        CrashBit(allRoad[indexArray]);

                    else CrashRoad(allRoad[indexArray]);
                }
            }

        }
        else
        {
            if (colliderStart)
            timeBeforeCrash -= 0.02f;
        }

        void CrashBit(GameObject gameobject)
        {
           
            if(gameobject.GetComponentInChildren<BrokenGlass>())
            bitArray = gameobject.GetComponentInChildren<BrokenGlass>().bitGross;

            if (rndVector == null)
            {
                rndVector = new Vector3[bitArray.Length];
                for (int i = 0; i < rndVector.Length; i++)
                {
                    rndVector[i] = new Vector3(Random.Range(-speedXVector, speedXVector), speedYVector, Random.Range(-speedZVector, speedZVector));
                }
                allRoad[indexArray].GetComponent<RoadTrigger>().brokenGlassArray.GetComponent<BoxCollider>().enabled = false;
            }

            for (int i = 0; i < bitArray.Length; i++)
            {
                if (allRoad[indexArray].GetComponent<RoadTrigger>().brokenGlassArray.activeInHierarchy)
                {
                    bitArray[i].transform.position += rndVector[i];
                    bitArray[i].transform.localScale -= minusScale;
                    if(bitArray[i].transform.localScale.x <= 0.1f)
                        Destroy(allRoad[indexArray]);
                }
            }
        }
        void CrashRoad(GameObject gameobject)
        {
            if (objectRoad)
            {
                if (objectRoad.GetComponent<MeshRenderer>().material.color.a > 0)
                    objectRoad.GetComponent<MeshRenderer>().material.color -= minusColor;
                else Destroy(gameobject);
            }
            else objectRoad = gameobject.GetComponent<RoadTrigger>().road;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        colliderStart = true;
    }



}
