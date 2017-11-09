using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement : MonoBehaviour {
    private float speed = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        deltaX *= Time.deltaTime;
        deltaZ *= Time.deltaTime;

        transform.Translate(deltaX, deltaZ, 0);
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.localPosition -= new Vector3(0, 0, transform.position.z  - 20);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.localPosition -= new Vector3(0,0, transform.position.z + 20);
        }
    }
    
}
