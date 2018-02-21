using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Rotate : MonoBehaviour {

    public float smooth = 1f;
    private Quaternion targetRotation;
    bool turn;
    Quaternion initRot;
    public float pos;
    public bool good;
    public int truePos;
    public float[] angles =new float[] { 0, 90, 180, 270 };
    void Start()
    {
        good = false;
        if (transform.name != "Recta")
        {
            if (transform.rotation.eulerAngles.z == 0)
            {
                pos = 0;
            }
            else if (transform.rotation.eulerAngles.z == 90 || transform.rotation.eulerAngles.z == -270)
            {
                pos = 1;
            }
            else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == -180)
            {
                pos = 2;
            }
            else if (transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == -90)
            {
                pos = 3;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.z == 0 || transform.rotation.eulerAngles.z == -360)
            {
                pos = 0;
            }
            else if (transform.rotation.eulerAngles.z == 90 || transform.rotation.eulerAngles.z == -270)
            {
                pos = 1;
            }
        }
        Vector3 euler = transform.eulerAngles;
        euler.z = angles[Random.Range(0, angles.Length)];
        transform.eulerAngles = euler;
        //transform.rotation.eulerAngles.z  = new Vector3(0,0,Random.Range(0, angles.Length));
        //targetRotation =null;
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.GetComponent<Button>().onClick.AddListener(clicked);
    }
    void OnMouseDown()
    {
        
        
    }
    void Update()
    {
        /* if (turn)
         {
             transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
         }*/
        if (transform.name != "Recta")
        {
            if (transform.rotation.eulerAngles.z == 0 || transform.rotation.eulerAngles.z == -360)
            {
                truePos = 0;
            }
            else if (transform.rotation.eulerAngles.z == 90 || transform.rotation.eulerAngles.z == -270)
            {
                truePos = 1;
            }
            else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == -180)
            {
                truePos = 2;
            }
            else if (transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == -90)
            {
                truePos = 3;
            }
        }
        else
        {
            if (transform.rotation.eulerAngles.z == 0 || transform.rotation.eulerAngles.z == -360)
            {
                truePos = 0;
            }
            else if (transform.rotation.eulerAngles.z == 90 || transform.rotation.eulerAngles.z == -270)
            {
                truePos = 1;
            }
        }
       
        if (truePos == pos)
        {
            good = true;
        }
        else
        {
            good = false;
        }
    }
    public void clicked()
    {
        turn = true;
        transform.rotation *= Quaternion.AngleAxis(-90, Vector3.forward);
    }
}
