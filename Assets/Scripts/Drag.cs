﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Drag : MonoBehaviour
{
    [SerializeField] Transform parentFront;
     Vector3 dist;
     float posX;
     float posY;
    GameObject copy;
    Ray ray;
    RaycastHit hit;
    bool move;
    Vector3 initPos;
    SuspectClass sus1;
    SuspectClass sus2;
    SuspectClass sus3;
    public GameObject[] minClues;
    private void OnMouseDown()
     {
        //copy = gameObject;
        /* dist = Camera.main.WorldToScreenPoint(transform.position);
         posX = Input.mousePosition.x - dist.x;
         posY = Input.mousePosition.y - dist.y;*/
     }
     void OnMouseDrag()
     {
        /* Vector3 curPos = new Vector3(Input.mousePosition.x - posX, Input.mousePosition.y - posY, dist.z);
         Vector3 worldPos = Camera.main.ScreenToWorldPoint(curPos);
        transform.position = worldPos;*/
     }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Studio")
        {
            sus1 = GameObject.Find("Suspect1").GetComponent<SuspectClass>();
            sus2 = GameObject.Find("Suspect2").GetComponent<SuspectClass>();
            sus3 = GameObject.Find("Suspect3").GetComponent<SuspectClass>();
            
            for(int i = 0; i < Player_Interaction.foundClues.Count; i++)
            {
                minClues[i].AddComponent<Clue_Index>();
                minClues[i].GetComponent<Clue_Index>().clueIndex = Player_Interaction.foundClues[i];
            }
        }
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit) && copy == null)
            {
                if (hit.transform.tag == "Clues")
                {
                    //print("click");
                    copy = hit.transform.gameObject;
                }
            }else if(Physics.Raycast(ray, out hit) && copy != null)
            {
                if (hit.transform.tag == "Suspect 1" )
                {
                    //print("unclick");
                    sus1.clues.Add(copy);
                    initPos = hit.transform.position;
                    move = true;
                    
                }else if(hit.transform.tag == "Suspect 2"){
                    sus2.clues.Add(copy);
                    initPos = hit.transform.position;
                    move = true;

                }
                else if (hit.transform.tag == "Suspect 3")
                {
                    sus3.clues.Add(copy);
                    initPos = hit.transform.position;
                    move = true;
                }
            }
        }
        if (move)
        {
            copy.transform.position = Vector3.Lerp(copy.transform.position,initPos, 0.1f);
            if(Vector3.Distance(copy.transform.position,initPos)<= 0.01f)
            {
                move = false;
                copy = null;
            }
        }

    }
}