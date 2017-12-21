using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccio_Proves : MonoBehaviour {
    
    public GameObject UV;
    public GameObject Polvos;
    public GameObject ADN;
    public GameObject seeThrough;
    public Player_Interaction interact;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
    }

    public void enableLightUV() {
       // seeThrough.SetActive(true);
        if (UV.activeSelf) {
            UV.SetActive(false);
        }else {
            UV.SetActive(true);
            Polvos.SetActive(false);
            ADN.SetActive(false);
        }
    }

    public void enableLightPO() {
      //  seeThrough.SetActive(true);
        if (Polvos.activeSelf) {
            Polvos.SetActive(false);
        }
        else {
            Polvos.SetActive(true);
            UV.SetActive(false);
            ADN.SetActive(false);
        }
    }

    public void enableLightADN() {
       // seeThrough.SetActive(true);
        if (ADN.activeSelf) {
            ADN.SetActive(false);
        }
        else {
            ADN.SetActive(true);
            UV.SetActive(false);
            Polvos.SetActive(false);
        }
    }
}
