using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccio_Proves : MonoBehaviour {
    
    public GameObject UV;
    public static bool uvLight;
    public GameObject Polvos;
    public static bool polvosLight;
    public GameObject ADN;
    public static bool adnLight;
    public GameObject seeThrough;
    [SerializeField]
    public Player_Interaction interact;
    [SerializeField]
    private GameObject fregona;
    // Use this for initialization
    void Start () {
                
    }
	
	// Update is called once per frame
	void Update () {
        if (interact.picked)
        {
            fregona = GameObject.Find("fregonaPista");
        }

    }

    public void enableLightUV() {
        // seeThrough.SetActive(true);
        
        if (uvLight) {
            uvLight = false;
            //UV.SetActive(false);
            
        }
        else {
            uvLight = true;
           // UV.SetActive(true);
            Polvos.SetActive(false);
            ADN.SetActive(false);
          
        }
       
    }

    public void enableLightPO() {
      //  seeThrough.SetActive(true);
        if (Polvos.activeSelf) {
            polvosLight = false;
            Polvos.SetActive(false);
        }
        else {
            polvosLight = true;
            Polvos.SetActive(true);
            UV.SetActive(false);
            ADN.SetActive(false);
        }
    }

    public void enableLightADN() {
       // seeThrough.SetActive(true);
        if (ADN.activeSelf) {
            adnLight = false;
            ADN.SetActive(false);
        }
        else {
            adnLight = true;
            ADN.SetActive(true);
            UV.SetActive(false);
            Polvos.SetActive(false);
        }
    }
}
