using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTexture : MonoBehaviour
{

    Transform tfLight;
    BoxCollider col;
    private void Start()
    {
        // find the revealing light named "RevealingLight":
        GameObject goLight = GameObject.FindGameObjectWithTag("LightUV");
        goLight.SetActive(false);
        if (goLight) tfLight = goLight.transform;
        //print("Hidden");
        col = GetComponent<BoxCollider>();
    }


    private void Update()
    {
        if (tfLight && Deteccio_Proves.uvLight)
        {
            col.enabled = true;
            GetComponent<Renderer>().material.SetVector("_LightPos", tfLight.position);
            GetComponent<Renderer>().material.SetVector("_LightDir", tfLight.forward);
            GetComponent<Renderer>().material.SetFloat("_SpotAngle", 10.0f);
        }
        else if(tfLight && !Deteccio_Proves.uvLight)
        {
            col.enabled = false;
            GetComponent<Renderer>().material.SetVector("_LightPos", tfLight.position);
            GetComponent<Renderer>().material.SetVector("_LightDir", tfLight.forward);
            GetComponent<Renderer>().material.SetFloat("_SpotAngle", 0.0f);
        }
    }
}


