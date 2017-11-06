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
            transform.position = new Vector3(transform.position.x, transform.position.y - .2f, transform.position.z);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .2f, transform.position.z);
        }
    }
}
