using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMIAManager : MonoBehaviour {
    public Material yellowMat;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("Tutorial") == 1)
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<Light>().color = Color.yellow;
            GetComponent<Renderer>().material = yellowMat;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (MovementMIA.clicked)
        {
            GetComponent<AudioSource>().Stop();
        }
    }
}
