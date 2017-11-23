using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class Player_Interaction : MonoBehaviour {
    RaycastHit interact;
    int count;
    public bool canPick;
    public bool picked;
    GameObject nou;
    GameObject vell;
    public PostProcessingProfile ppProfile;
    public GameObject panel;
    public Transform test;
    public Texture2D mouse;
   // public Object_Movement move;
    // Use this for initialization
    void Start () {
        count = 0;
        picked = false;
        ppProfile.depthOfField.enabled = false;
        ppProfile.vignette.enabled = false;
        //ppProfile = Camera.main.GetComponent<PostProcessingProfile>();
    }
	
	// Update is called once per frame
	void Update () {
        Debug.DrawRay(transform.position,transform.forward *1.5f,Color.green);
        
            if (Physics.Raycast(transform.position, transform.forward, out interact, 1.5f) && !picked)
            {
                if(interact.collider.tag == "Interact")
                {
                    print("PICK");
                }
                if ((interact.collider.tag != "Paret") && (interact.collider.tag != "Terra"))
                {
                    canPick = true;
                }
                else
                {

                    canPick = false;
                }

            }

            else
            {

                canPick = false;
            }
        

        if (canPick && Input.GetKeyDown(KeyCode.E) && !picked)
        {
            ppProfile.depthOfField.enabled = true;
            ppProfile.vignette.enabled = true;
            //Camera.main.GetComponent<PostProcessingProfile>().depthOfField.settings = ppProfile.depthOfField.settings;
            Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.None;
           // panel.SetActive(true);
            //panel.transform.localPosition = new Vector3(0, 0, 500);
            //panel.transform.localScale = new Vector3(10,10,10);
            vell = interact.collider.gameObject;
            vell.SetActive(false);
            nou = (GameObject)Instantiate(interact.collider.gameObject);
            nou.SetActive(true);
            nou.layer = 5;
            //transform.rotation = new Quaternion(0, 0, 0, 0);
            nou.GetComponent<BoxCollider>().enabled = false;
            //Destroy(nou.GetComponent<Rigidbody>());
            nou.transform.parent = GameObject.Find("Canvas").transform;
            nou.transform.localPosition = new Vector3(0,0,0);
            nou.transform.rotation = new Quaternion(0, 0, 0, 0);
            nou.AddComponent<Object_Movement>();
            nou.GetComponent<Object_Movement>().alpha = 100;
            nou.AddComponent<rot_Obj>();
            picked = true;
        }
        else if(picked && Input.GetKeyDown(KeyCode.E) && picked)
        {
            ppProfile.depthOfField.enabled = false;
            ppProfile.vignette.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            //panel.SetActive(false);
            vell.SetActive(true);
            Destroy(nou);
            picked = false;
        }
        
    }
}
