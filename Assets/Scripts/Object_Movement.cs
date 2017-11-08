using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.localPosition -= new Vector3(0, 0, transform.position.z  - 50);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.localPosition -= new Vector3(0,0, transform.position.z + 50);
        }
    }
}
