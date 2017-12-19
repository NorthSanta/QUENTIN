using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player_Interaction : MonoBehaviour {
    RaycastHit interact;
    int count;
    public bool canPick;
    public bool picked;
    GameObject nou;
    GameObject vell;
    public PostProcessingProfile ppProfile;
    public GameObject lupa;
    public GameObject punter;
    public Image icon;
    public Collider col;
    private GameObject myCanvas;
    public Camera canvasCam;
    [SerializeField] private Transform target;
    [SerializeField] private Studio_Interaction studio_Script;
    private bool inStudio;
    private float interactDistance;
    // public Object_Movement move;
    // Use this for initialization
    void Start () {

        if (SceneManager.GetActiveScene().name == "Studio") {
            inStudio = true;
            interactDistance = 2.0f;
        }
        else {
            inStudio = false;
            interactDistance = 1.5f;
        }

        count = 0;
        picked = false;
        ppProfile.depthOfField.enabled = false;
        ppProfile.vignette.enabled = false;
        myCanvas = GameObject.Find("trueCanvas");
        Cursor.visible = false;
        myCanvas.SetActive(false);
        //ppProfile = Camera.main.GetComponent<PostProcessingProfile>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if(inStudio) {
            lookMap(studio_Script.mapEnabled);
        }
   
        Debug.DrawRay(transform.position,transform.forward * interactDistance,Color.green);
        
            if (Physics.Raycast(transform.position, transform.forward, out interact, interactDistance) && !picked) {
                /*if(interact.collider.tag == "Interact")
                {
                    icon.sprite = lupa;
                    print("PICK");
                }*/
                switch (interact.collider.tag) {
                    case "Interact":
                        col = interact.collider;
                        lupa.SetActive(true);
                        punter.SetActive(false);
                        canPick = true;
                        break;
                    case "Door":
                        canPick = false;
                        //Make the transition & door animation bool to true;
                        //TODO
                        if (Input.GetKeyDown(KeyCode.E)) {
                            if (!inStudio) {
                                PlayerPrefs.SetString("SelectedCase", "Studio");
                            }
                            SceneManager.LoadScene("Loading");
                        }
                        break;
                    case "Map":
                        canPick = false;
                        if (Input.GetKeyDown(KeyCode.E)) {
                            transform.parent.position = new Vector3(-0.6287f, 1.5f, -0.6045f);
                            transform.parent.eulerAngles = new Vector3(0, 207.746f, 0);
                            transform.localEulerAngles = new Vector3(8.1f, 0, 0);
                            //transform.LookAt(target);
                            studio_Script.mapEnabled = true;
                        }
                        break;
                    default:
                        canPick = false;
                        break;
                }
            }
            else {
            punter.SetActive(true);
            lupa.SetActive(false);
            canPick = false;
            }
        

        if (canPick && Input.GetKeyDown(KeyCode.E) && !picked) {
            myCanvas.SetActive(true);
            ppProfile.depthOfField.enabled = true;
            ppProfile.vignette.enabled = true;

            //Camera.main.GetComponent<PostProcessingProfile>().depthOfField.settings = ppProfile.depthOfField.settings;
            //Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.None;
           
            vell = interact.collider.gameObject;
            vell.SetActive(false);
            nou = (GameObject)Instantiate(interact.collider.gameObject);
            nou.SetActive(true);
            nou.layer = 4;

            if (col.GetType() == typeof(BoxCollider))
                nou.GetComponent<BoxCollider>().enabled = false;
            else if (col.GetType() == typeof(MeshCollider))
                nou.GetComponent<MeshCollider>().enabled = false;
            

            nou.transform.parent =myCanvas.transform;
            nou.transform.SetAsFirstSibling();
            nou.transform.localPosition = new Vector3(0,0,0);
            nou.transform.rotation = new Quaternion(0, 0, 0, 0);
            nou.AddComponent<Object_Movement>();
            nou.GetComponent<Object_Movement>().alpha = 100;
            nou.AddComponent<rot_Obj>();
            picked = true;
        }
        else if(picked && Input.GetKeyDown(KeyCode.E) && picked) {
            myCanvas.SetActive(false);
            ppProfile.depthOfField.enabled = false;
            ppProfile.vignette.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            //panel.SetActive(false);
            vell.SetActive(true);
            Destroy(nou);
            picked = false;
        }

        if (picked) {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, canvasCam, out pos);
            icon.transform.position = myCanvas.transform.TransformPoint(pos);
        }
        else {
            icon.transform.localPosition = new Vector3(0, 0, 0);
        }
        
    }

    void lookMap(bool enabled)  {
        if (enabled) {
            punter.SetActive(false);
            GetComponent<Camera_Control>().enabled = false;
            transform.parent.GetComponent<Camera_Control>().enabled = false;
            transform.parent.GetComponent<Player_Movement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
        }
        else {
            //transform.LookAt(transform.parent.forward);
            punter.SetActive(true);
            GetComponent<Camera_Control>().enabled = true;
            transform.parent.GetComponent<Camera_Control>().enabled = true;
            transform.parent.GetComponent<Player_Movement>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
