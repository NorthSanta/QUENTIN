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
        if (goLight) tfLight = goLight.transform;
    }


    private void Update()
    {
        if (tfLight)
        {
            GetComponent<Renderer>().material.SetVector("_LightPos", tfLight.position);
            GetComponent<Renderer>().material.SetVector("_LightDir", tfLight.forward);
        }
    }
}


