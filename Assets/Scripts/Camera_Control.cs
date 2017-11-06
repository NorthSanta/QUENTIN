using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour {

	
    public enum RotAxis
    {
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

    private void Start()
    {
        interact = GetComponent<Player_Interaction>();
    }
    void Update () {
        if (!interact.picked)
        {
            if (axis == RotAxis.xAxis)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensHorz, 0);
            }
            else if (axis == RotAxis.yAxis)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensVert;
                _rotationX = Mathf.Clamp(_rotationX, minVert, maxVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
        
    }
}
