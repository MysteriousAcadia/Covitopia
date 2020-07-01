using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;
    private bool moveRight = true;
    private float distTravelled = 0f;
    

    void Update()
    {
        if (moveRight)
        {
            layer1.transform.position -= new Vector3(Mathf.Lerp(0, 40, Time.deltaTime)*2f,0 , 0);
            layer2.transform.position -= new Vector3(Mathf.Lerp(0, 40, Time.deltaTime)*1.4f, 0, 0);
            layer3.transform.position -= new Vector3(Mathf.Lerp(0, 40, Time.deltaTime), 0, 0);
            distTravelled += Mathf.Lerp(0, 40, Time.deltaTime) * 2f;
        }
        else
        {
            layer1.transform.position += new Vector3(Mathf.Lerp(0, 40, Time.deltaTime)*2f,0 , 0);
            layer2.transform.position += new Vector3(Mathf.Lerp(0, 40, Time.deltaTime)*1.4f, 0, 0);
            layer3.transform.position += new Vector3(Mathf.Lerp(0, 40, Time.deltaTime), 0, 0);
            distTravelled += Mathf.Lerp(0, 40, Time.deltaTime) * 2f;
        }

        if (distTravelled > 1200)
        {
            moveRight = !moveRight;
            distTravelled = 0;
        }
        
        
    }
}
