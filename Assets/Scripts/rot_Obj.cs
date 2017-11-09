using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot_Obj : MonoBehaviour {

    // Use this for initialization
    void OnMouseDrag()
    {
        print("dragg");
        float rotX = Input.GetAxis("Mouse X") * 20 * Mathf.Deg2Rad;
        float rotY = Input.GetAxis("Mouse Y") * 20 * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -rotX);
        transform.RotateAround(Vector3.right, rotY);
    }
}
