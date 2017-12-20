using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llibreta_Fade : MonoBehaviour {
    public float cool;
	// Use this for initialization
	void Start () {
        cool = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
        cool -= Time.deltaTime;
        if(cool<= 0)
        {
            gameObject.SetActive(false);
            cool = 2.5f;
        }
	}
}
