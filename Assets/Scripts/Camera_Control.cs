using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour {
	
    public enum RotAxis {
         xAxis = 1,
         yAxis = 2
    }

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    public RotAxis axis = RotAxis.xAxis;
    public float sensHorz = 10.0f;
    public float sensVert = -1.0f;

    public float _rotationX = 0;
    // Update is called once per frame
    public Player_Interaction interact;

    public bool crouch;
    public float crouchHeight;

    

    private void Start() {
        interact =  Camera.main.GetComponent<Player_Interaction>();
        crouchHeight = transform.position.y;
        
        crouch = false;
    }

    void Update () {
        if (!interact.picked && !interact.PistaPicked) {
            if (axis == RotAxis.xAxis) {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorz, 0);
            }
            else if (axis == RotAxis.yAxis) {
                _rotationX -= Input.GetAxis("Mouse Y") * sensVert;
                _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }

            //if (Input.GetKeyDown(KeyCode.LeftControl) && !crouch )
            //{
            //    float step = 1 * Time.deltaTime;
            //    //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, crouchHeight / 2, transform.position.z), 0.1f);
                
            //    transform.position = new Vector3(transform.position.x, crouchHeight/1.5f, transform.position.z);
            //    //this.GetComponent<CapsuleCollider>(). -= Vector3(0, crouchDeltaHeight, 0);
            //    //this.GetComponent<CapsuleCollider>().height -= crouchHeight;
            //    //crouching = true;
            //    crouch = true;
            //}
            //else if (Input.GetKeyUp(KeyCode.LeftControl) && crouch )
            //{
            //    float step = 1 * Time.deltaTime;
            //    //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, crouchHeight, transform.position.z), 0.1f);
            //    transform.position = new Vector3(transform.position.x, crouchHeight, transform.position.z);
            //    //this.GetComponent<CapsuleCollider>().height += crouchHeight;
            //    crouch = false;
            //}
        }
    }
}
