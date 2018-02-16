﻿using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour
{
    [SerializeField] Transform parentFront;
     Vector3 dist;
     float posX;
     float posY;
     private void OnMouseDown()
     {
         dist = Camera.main.WorldToScreenPoint(transform.position);
         posX = Input.mousePosition.x - dist.x;
         posY = Input.mousePosition.y - dist.y;
     }
     void OnMouseDrag()
     {
         Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
         Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;
     }
    /*private float factor = 4;
    private float factorV = 10;

    private Vector3 v3StartPos;  // Initial position of object
    private Vector3 v3DownPos;   // Initial position of the mouse in world coordinates
    private float fZMap;
    Vector3 v3T;// Base Z distance to use in conversion
    private void OnMouseDown()
    {
        v3StartPos = transform.localPosition;
        Vector3 v3T = Camera.main.WorldToScreenPoint(v3StartPos);
        fZMap = v3T.z;
        v3DownPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, fZMap);
        v3DownPos = Camera.main.ScreenToWorldPoint(v3DownPos);
    }

    private void OnMouseDrag()
    {
        v3T = new Vector3(Input.mousePosition.x, Input.mousePosition.y, fZMap);
        v3T = Camera.main.ScreenToWorldPoint(v3T);

        Vector3 v3T2 = v3StartPos;
        v3T2 = v3StartPos;
        v3T2.x = v3T2.x + (v3T.x - v3DownPos.x) * factor;
        v3T2.z = v3T2.z - (v3T.y - v3DownPos.y) * factorV;

        transform.localPosition = v3T2;
    }*/
}