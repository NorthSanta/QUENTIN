using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llibreta_Fade : MonoBehaviour {
    private float cool;
    public float max;
	// Use this for initialization
	void Start () {
        //cool = 2.5f;
        cool = max;
	}
	
	// Update is called once per frame
	void Update () {
        cool -= Time.deltaTime;
        if(cool<= 0)
        {
            gameObject.SetActive(false);
            cool = max;
        }
	}
}
