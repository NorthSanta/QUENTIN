using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccio_Proves : MonoBehaviour {
    RaycastHit interact;
    public GameObject UV;
    public GameObject Polvos;
    public GameObject ADN;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
    }

    public void enableLightUV()
    {
        if (UV.activeSelf)
        {
            UV.SetActive(false);
        }else
        {
            UV.SetActive(true);
            Polvos.SetActive(false);
            ADN.SetActive(false);
        }
       
    }
    public void enableLightPO()
    {

        if (Polvos.activeSelf)
        {
            Polvos.SetActive(false);
        }
        else
        {
            Polvos.SetActive(true);
            UV.SetActive(false);
            ADN.SetActive(false);
        }
    }
    public void enableLightADN()
    {

        if (ADN.activeSelf)
        {
            ADN.SetActive(false);
        }
        else
        {
            ADN.SetActive(true);
            UV.SetActive(false);
            Polvos.SetActive(false);
        }
    }
}
