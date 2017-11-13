using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot_Obj : MonoBehaviour {

    
    // Use this for initialization
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("dragg");
            float rotX = Input.GetAxis("Mouse X") * 3.5f * Mathf.Deg2Rad;
            float rotY = Input.GetAxis("Mouse Y") * 3.5f * Mathf.Deg2Rad;
            
            transform.RotateAroundLocal(Vector3.up, -rotX);
            transform.RotateAroundLocal(Vector3.right, rotY);
        }
    }
}
