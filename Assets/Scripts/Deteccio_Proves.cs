using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deteccio_Proves : MonoBehaviour {
    RaycastHit interact;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     
    }

    public void enableLight(GameObject light)
    {
      
        light.SetActive(true);
    }
}
