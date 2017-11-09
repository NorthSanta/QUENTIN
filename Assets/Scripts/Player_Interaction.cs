using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour {
    RaycastHit interact;
    int count;
    public bool canPick;
    public bool picked;
    GameObject nou;
    GameObject vell;
    public Transform test;
   // public Object_Movement move;
    // Use this for initialization
    void Start () {
        count = 0;
        picked = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position,transform.forward *1.5f,Color.green);
       
       if( Physics.Raycast(transform.position,transform.forward,out interact, 1.5f) && !picked){
            if(interact.collider.tag == "Interact")
            {
                
                canPick = true;
                //count++;
            }else
            {
                canPick = false;
            }
            //print("OBJECT");
        }
        if(canPick && Input.GetKeyDown(KeyCode.E) && !picked)
        {
            vell = interact.collider.gameObject;
            vell.SetActive(false);
            nou = (GameObject)Instantiate(interact.collider.gameObject);
            nou.SetActive(true);
            
            nou.GetComponent<BoxCollider>().enabled = false;
            //Destroy(nou.GetComponent<Rigidbody>());
            nou.transform.parent = GameObject.Find("Canvas").transform;
            nou.transform.localPosition = new Vector3(0,0,0);
            nou.transform.rotation = new Quaternion(0, 0, 0, 0);
            nou.AddComponent<Object_Movement>();
            nou.AddComponent<rot_Obj>();
            picked = true;
        }
        else if(picked && Input.GetKeyDown(KeyCode.E) && picked)
        {
            vell.SetActive(true);
            Destroy(nou);
            picked = false;
        }
        
    }
}
