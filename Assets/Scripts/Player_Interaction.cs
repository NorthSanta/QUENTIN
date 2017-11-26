using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

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
    public Image icon;
    public Sprite lupa;
    public Sprite quadrat;
    private GameObject myCanvas;
    // public Object_Movement move;
    // Use this for initialization
    void Start () {
        count = 0;
        picked = false;
        ppProfile.depthOfField.enabled = false;
        ppProfile.vignette.enabled = false;
        myCanvas = GameObject.Find("Canvas");
        Cursor.visible = false;
        //ppProfile = Camera.main.GetComponent<PostProcessingProfile>();
    }
	
	// Update is called once per frame
	void Update () {
        icon.sprite = quadrat;
        Debug.DrawRay(transform.position,transform.forward *1.5f,Color.green);
        
            if (Physics.Raycast(transform.position, transform.forward, out interact, 1.5f) && !picked)
            {
                /*if(interact.collider.tag == "Interact")
                {
                    icon.sprite = lupa;
                    print("PICK");
                }*/
                if ((interact.collider.tag != "Paret") && (interact.collider.tag != "Terra"))
                {
                    icon.sprite = lupa;
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
            //Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.None;
           
            vell = interact.collider.gameObject;
            vell.SetActive(false);
            nou = (GameObject)Instantiate(interact.collider.gameObject);
            nou.SetActive(true);
            nou.layer = 5;
            
            nou.GetComponent<BoxCollider>().enabled = false;

            nou.transform.parent =myCanvas.transform;
            nou.transform.SetAsFirstSibling();
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

        if (picked)
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, Camera.main, out pos);
            icon.transform.position = myCanvas.transform.TransformPoint(pos);
        }
        
    }
}
