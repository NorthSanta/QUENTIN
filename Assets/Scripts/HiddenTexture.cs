using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenTexture : MonoBehaviour
{

    Transform tfLight;

    private void Start()
    {
        // find the revealing light named "RevealingLight":
        GameObject goLight = GameObject.Find("RevealingLight");
        goLight.SetActive(false);
        if (goLight) tfLight = goLight.transform;
        print("Hidden");
    }


    private void Update()
    {
        if (tfLight && Deteccio_Proves.uvLight)
        {
            GetComponent<Renderer>().material.SetVector("_LightPos", tfLight.position);
            GetComponent<Renderer>().material.SetVector("_LightDir", tfLight.forward);
            GetComponent<Renderer>().material.SetFloat("_SpotAngle", 10.0f);
        }
        else if(tfLight && !Deteccio_Proves.uvLight)
        {
            GetComponent<Renderer>().material.SetVector("_LightPos", tfLight.position);
            GetComponent<Renderer>().material.SetVector("_LightDir", tfLight.forward);
            GetComponent<Renderer>().material.SetFloat("_SpotAngle", 0.0f);
        }
    }
}


