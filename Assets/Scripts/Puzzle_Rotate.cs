using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Rotate : MonoBehaviour
{

    public float smooth = 1f;
    private Quaternion targetRotation;
    bool turn;
    Quaternion initRot;
    public float pos;
    public bool good;
    public int truePos;
    public bool done;
    public int[] angles = new int[] { 0, -90, -180, -270 };
    float vz;
    public int i;
    void Start()
    {

        good = false;
        //if (transform.name == "Recta")
        //{
        //    if (transform.rotation.eulerAngles.z == 0 || transform.rotation.eulerAngles.z == -180)
        //    {
        //        pos = 0;
        //    }
        //    else if (transform.rotation.eulerAngles.z == -90 || transform.rotation.eulerAngles.z == -270)
        //    {
        //        pos = 1;
        //    }

        //}
        //else
        //{
        //    if (transform.rotation.eulerAngles.z == 0)
        //    {
        //        pos = 0;
        //    }
        //    else if (transform.rotation.eulerAngles.z == -90)
        //    {
        //        pos = 1;
        //    }
        //    else if (transform.rotation.eulerAngles.z == -180)
        //    {
        //        pos = 2;
        //    }
        //    else if (transform.rotation.eulerAngles.z == -270)
        //    {
        //        pos = 3;
        //    }
        //}
        Vector3 euler = transform.eulerAngles;
        i = Random.Range(0, angles.Length);
        euler.z = angles[i];
        transform.eulerAngles = euler;
        vz = transform.eulerAngles.z;

        if (transform.name == "Recta")
        {
            if (i == 0 || i == 2)
            {
                truePos = 0;
            }
            else if (i == 1 || i == 3)
            {
                truePos = 1;
            }

        }
        else
        {
            truePos = i;
        }
        if (transform.name == "Puta")
        {
            print(vz);
            print(i);
        }
            //transform.rotation.eulerAngles.z  = new Vector3(0,0,Random.Range(0, angles.Length));
            //targetRotation =null;
            gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.GetComponent<Button>().onClick.AddListener(clicked);
        done = true;
        //gameObject.SetActive(false);
    }
    void OnMouseDown()
    {


    }
    void Update()
    {

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
        truePos++;
        if (transform.name == "Recta")
        {
            truePos %= 2;
        }
        else
        {
            truePos %= 4;
        }
    }
}
