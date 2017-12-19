using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement : MonoBehaviour {
    private float speed = 1;

    [SerializeField]
    public int alpha;
    public float scale;
    public int offSet;
    private Camera canvas;
	// Use this for initialization
	void Start () {
        scale = transform.localScale.z;
        offSet = 300;
        canvas = GameObject.Find("CanvasCamera").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        float deltaX = Input.GetAxis("Horizontal") * speed ;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        deltaX *= Time.deltaTime;
        deltaZ *= Time.deltaTime;

        if (transform.localPosition.x >= -550 && transform.localPosition.x <= 550) {
            //print("horz");
            transform.Translate(deltaX, 0, 0, canvas.transform);
        }
        if (transform.localPosition.y >= -180 && transform.localPosition.y <= 180) {
            //print("Vert");
            transform.Translate(0, deltaZ, 0, canvas.transform);
        }

        if(transform.localPosition.x < -550f) {
            transform.localPosition = new Vector3(-550, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x > 550f) {
            transform.localPosition = new Vector3(550, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.y < -180) {
            transform.localPosition = new Vector3(transform.localPosition.x, -180, transform.localPosition.z);
        }
        else if (transform.localPosition.y > 180) {
            transform.localPosition = new Vector3(transform.localPosition.x, 180, transform.localPosition.z);
        }



        if (Input.GetAxis("Mouse ScrollWheel") < 0 && transform.localScale.z >= scale - offSet) {
            transform.localScale -= new Vector3(alpha, alpha, alpha);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 && transform.localScale.z <= scale + offSet) {
            transform.localScale += new Vector3(alpha, alpha, alpha);
        }
    }
    
}
