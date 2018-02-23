using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;


public class Player_Interaction : MonoBehaviour
{
    [SerializeField]
    Material switchMat;
    [SerializeField]
    Material def;

    [SerializeField]
    GameObject textPuzzle;
    public static bool puzzDone;
    int count = 0;
    public static List<int> foundClues = new List<int>();
    RaycastHit interact;
    public GameObject puzzlePieces;
    public GameObject map;
    public bool canPick;
    public bool interactuable;
    public bool picked;
    public bool canPuzzle;
    public static bool inPuzzle;
    public GameObject llibreta;
    public GameObject textPista;
    public Clue_Manager manager;
    public int indexClue;
    public int cluesFound;
    GameObject nou;
    GameObject vell;
    public PostProcessingProfile ppProfile;
    public GameObject lupa;
    public GameObject punter;
    public Image icon;
    public Collider col;
    public GameObject MENU;
    public GameObject buttons;
    public Camera canvasCam;
    [SerializeField] private Transform target;
    [SerializeField] public Studio_Interaction studio_Script;
    [SerializeField] private Animator liftController;
    [SerializeField] private Animator doorController;
    private bool inStudio;
    public float interactDistance;

    public GameObject UV;
    public GameObject Polvos;
    public GameObject ADN;

    public GameObject puzzleProg;
    // public Object_Movement move;
    // Use this for initialization
    void Start() {
        //PlayerPrefs.DeleteAll();
        if (SceneManager.GetActiveScene().name == "Studio") {
            inStudio = true;
            interactDistance = 2.0f;
        }
        else {
            inStudio = false;
            interactDistance = 1.5f;
        }

        picked = false;
        ppProfile.depthOfField.enabled = false;
        ppProfile.vignette.enabled = false;
        buttons.SetActive(false);
        MENU.SetActive(false);
        cluesFound = 0;
        Cursor.visible = false;
        
        //myCanvas = GameObject.Find("trueCanvas");
        //Cursor.visible = false;
        //myCanvas.SetActive(false);
        //ppProfile = Camera.main.GetComponent<PostProcessingProfile>();
    }

    // Update is called once per frame
    void Update() {
        //print(foundClues.Count);
        //ClearLog();
        /*Debug.Log("Position: " + transform.position);
        Debug.Log("Rotation: " + transform.rotation);*/
        if (inStudio) {
            lookMap(studio_Script.mapEnabled);
        }
        if (interactuable) {
            if (!lupa.activeSelf) lupa.SetActive(true);
            if (punter.activeSelf) punter.SetActive(false);
        }
        else {
            if (lupa.activeSelf) lupa.SetActive(false);
            if (!punter.activeSelf) punter.SetActive(true);
        }


        Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.green);

        if (Physics.Raycast(transform.position, transform.forward, out interact, interactDistance) && !picked) {
            switch (interact.collider.tag) {
                case "Interact":
                    col = interact.collider;
                    interactuable = true;
                    canPick = true;
                    break;
                case "Door":
                    canPick = false;
                    interactuable = false;
                    //Make the transition & door animation bool to true;
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (!inStudio) {
                            PlayerPrefs.SetString("SelectedCase", "Studio");
                        }
                        doorController.SetBool("Active", true);

                        SceneManager.LoadScene("Loading");
                    }
                    break;
                case "Map":
                    canPick = false;
                    interactuable = false;
                    if (Input.GetKeyDown(KeyCode.E)) {
                        //transform.parent.position = new Vector3(-0.5857f, 1.5f, -0.5630f);
                        // transform.parent.rotation = new Quaternion(0.0f, 1.0f, 0.0f, -0.24f);
                        //transform.rotation.Set(0.0f, 1.0f, -0.05f, -0.24f);// = new Quaternion(0.0f, 1.0f, -0.05f, -0.24f);
                        //transform.parent.eulerAngles = new Vector3(0, -0.5630f, 0);
                        //transform.parent.rotation = Quaternion.Lerp(transform.rotation, map.transform.rotation, Time.time );
                       // transform.parent.rotation = Quaternion.Lerp(transform.rotation, map.transform.rotation, Time.time);
                        studio_Script.mapEnabled = true;
                    }
                    break;
                case "Lift":
                    canPick = false;
                    interactuable = false;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        liftController.SetBool("Active", true);
                    }
                    break;
                case "RastreV":
                    //sprint("uolo");
                    col = interact.collider;
                    interactuable = true;
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (!interact.collider.gameObject.GetComponent<Clue_Index>().found) {
                            indexClue = interact.collider.gameObject.GetComponent<Clue_Index>().clueIndex;
                            cluesFound++;
                            interact.collider.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                            interact.collider.gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMesh>().text = cluesFound.ToString();
                            textPista.GetComponent<Text>().text = manager.caseClues[indexClue];
                            PlayerPrefs.SetString("office" + cluesFound, manager.caseClues[indexClue]);
                            //PlayerPrefs.SetInt("office" + cluesFound++, indexClue);
                            interact.collider.gameObject.GetComponent<Clue_Index>().found = true;
                            foundClues.Add(interact.collider.gameObject.GetComponent<Clue_Index>().clueIndex);
                            //textPista.GetComponent<Text>().text = PlayerPrefs.GetString("office" + indexClue);
                            llibreta.SetActive(true);
                            textPista.SetActive(true);
                        }
                    }
                    //canPick = true;
                    break;
                case "Puzzle":
                    interactuable = true;
                    canPuzzle = true;
                       
                    
                    /* if (Input.GetKeyDown(KeyCode.E)) {
                         puzzleProg.SetActive(!puzzleProg.activeSelf);
                         punter.SetActive(false);
                         lupa.SetActive(false);
                         GetComponent<Camera_Control>().enabled = false;
                         transform.parent.GetComponent<Camera_Control>().enabled = false;
                         transform.parent.GetComponent<Player_Movement>().enabled = false;
                         Cursor.lockState = CursorLockMode.Confined;
                     }else if (Input.GetKeyDown(KeyCode.R)) {
                         GetComponent<Camera_Control>().enabled = true;
                         transform.parent.GetComponent<Camera_Control>().enabled = true;
                         transform.parent.GetComponent<Player_Movement>().enabled = true;
                         Cursor.lockState = CursorLockMode.Locked;
                     }*/
                    break;
                default:
                    canPick = false;
                    canPuzzle = false;
                    interactuable = false;
                    break;
            }
        }
        else
        {
            interactuable = false;
            canPick = false;
        }
        //print(foundClues.Count);
        //print(foundClues.Count);
        if (canPuzzle && Input.GetKeyDown(KeyCode.E) && !inPuzzle)

        {
            ppProfile.depthOfField.enabled = true;
            ppProfile.vignette.enabled = true;

            puzzlePieces.SetActive(true);
          

            vell = interact.collider.gameObject;
            vell.SetActive(false);
            nou = (GameObject)Instantiate(interact.collider.gameObject);
           // GameObject copy = (GameObject)Instantiate(interact.collider.gameObject);
            nou.SetActive(true);
            nou.layer = 4;

            nou.GetComponent<BoxCollider>().enabled = false;
           // copy.GetComponent<BoxCollider>().enabled = false;

            nou.transform.parent = buttons.transform.parent;
            nou.transform.SetAsFirstSibling();
            nou.transform.localPosition = new Vector3(0, 0, 10);
            nou.transform.localRotation = new Quaternion(0.7071068f, 0.7071068f, 0, 0);
            nou.transform.localScale = new Vector3(5000, 5000, 900);
            //Debug.Log("puxxle");
            inPuzzle = true;
            picked = true;
        }
        else if (canPick && Input.GetKeyDown(KeyCode.E) && !picked){
            buttons.SetActive(true);
            ppProfile.depthOfField.enabled = true;
            ppProfile.vignette.enabled = true;

            //Camera.main.GetComponent<PostProcessingProfile>().depthOfField.settings = ppProfile.depthOfField.settings;
            //Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
            // Cursor.lockState = CursorLockMode.Confined;
           
            vell = interact.collider.gameObject;
            def = vell.GetComponent<Renderer>().material;
            vell.SetActive(false);
            nou = (GameObject)Instantiate(interact.collider.gameObject);
            //nou.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
            

            /*Shader s = Shader.Find("Standard");
            
            for (int i = 0;i < mats.Length; i++)
            {
                print(mats.Length);
                mats[i].shader = s;
            }*/
            //nou.GetComponent<GlowObject>().enabled = false;
            // GameObject copy = (GameObject)Instantiate(interact.collider.gameObject);
            nou.SetActive(true);
            nou.layer = 4;
            //nou.GetComponent<GlowObject>().enabled = false;
            if (col.GetType() == typeof(BoxCollider))
            {
                nou.GetComponent<BoxCollider>().enabled = false;
                //copy.GetComponent<BoxCollider>().enabled = false;
            }
            else if (col.GetType() == typeof(MeshCollider))
            {
                nou.GetComponent<MeshCollider>().enabled = false;
                //copy.GetComponent<MeshCollider>().enabled = false;
            }

            //nou.GetComponent<Renderer>().material = switchMat;
            nou.transform.parent = buttons.transform.parent;
            nou.transform.SetAsFirstSibling();
            nou.transform.localPosition = new Vector3(0, 0, 0);
            nou.transform.rotation = new Quaternion(0, 0, 0, 0);
            //nou.transform.localScale = new Vector3(0, 0, 0);
            /*nou.GetComponent<GlowObject>().enabled = false;
            nou.AddComponent<PermaGlow>()._targetColor = Color.black;*/
            nou.AddComponent<Object_Movement>();
            nou.GetComponent<Object_Movement>().alpha = 100;
            nou.AddComponent<rot_Obj>();
            nou.AddComponent<ApplyPlayerPos>();
            // copy.transform.parent = buttons.transform.parent;
            //// copy.transform.SetAsFirstSibling();
            // copy.transform.localPosition = new Vector3(0, 0, 0);
            // copy.transform.rotation = new Quaternion(0, 0, 0, 0);
            // copy.AddComponent<Object_Movement>();
            // copy.GetComponent<Object_Movement>().alpha = 100;
            // copy.AddComponent<rot_Obj>();
            // copy.layer = 8;
            // copy.SetActive(true);
            //copy.GetComponent<>().color = Color.red;


            picked = true;
        }
        else if ((picked && Input.GetKeyDown(KeyCode.E) && PlayerPrefs.GetString("SelectedCase")!= "Studio") || (inPuzzle && Input.GetKeyDown(KeyCode.E) && PlayerPrefs.GetString("SelectedCase") != "Studio"))
        {
            UV.SetActive(false);
            Polvos.SetActive(false);
            ADN.SetActive(false);
            Deteccio_Proves.uvLight= false;
            Deteccio_Proves.polvosLight = false;
            Deteccio_Proves.adnLight = false;
            buttons.SetActive(false);
            ppProfile.depthOfField.enabled = false;
            ppProfile.vignette.enabled = false;
            //Cursor.lockState = CursorLockMode.Locked;
            //panel.SetActive(false);
            vell.SetActive(true);
            Destroy(nou);
            picked = false;
            puzzlePieces.SetActive(false);
            textPuzzle.SetActive(false);
            inPuzzle = false;
            //Debug.Log("NO puxxle");
        }

        if(picked && nou != null && Deteccio_Proves.uvLight)
        {
            nou.GetComponent<Renderer>().material = switchMat;
        }
        else if(nou!= null && !inPuzzle)
        {
            nou.GetComponent<Renderer>().material = def;
        }
        if(inPuzzle && puzzDone && count < 1)
        {
            puzzlePieces.SetActive(false);
            textPuzzle.SetActive(true);
            indexClue = 3;
            puzzleProg.SetActive(true);
            cluesFound++;
            puzzleProg.transform.GetChild(0).GetComponent<TextMesh>().text = cluesFound.ToString();
            textPista.GetComponent<Text>().text = manager.caseClues[indexClue];
            PlayerPrefs.SetString("office" + cluesFound, manager.caseClues[indexClue]);
            //PlayerPrefs.SetInt("office" + cluesFound++, indexClue);
            //interact.collider.gameObject.GetComponent<Clue_Index>().found = true;
            foundClues.Add(indexClue);
            //textPista.GetComponent<Text>().text = PlayerPrefs.GetString("office" + indexClue);
            llibreta.SetActive(true);
            textPista.SetActive(true);
            count++;
        }
        if (picked || inPuzzle){
            Cursor.lockState = CursorLockMode.None;
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(buttons.transform.parent.transform as RectTransform, Input.mousePosition, canvasCam, out pos);
            icon.transform.position = buttons.transform.parent.transform.TransformPoint(pos);
        }
        else{
            Cursor.lockState = CursorLockMode.Locked;
            icon.transform.localPosition = new Vector3(0, 0, 0);
            
        }

    }

    void lookMap(bool enabled) {
        //print(enabled);
        if (enabled || manager.GetComponent<MenuManager>().inMenu) {
            picked = true;
            punter.SetActive(false);
            GetComponent<Camera_Control>().enabled = false;
            transform.parent.GetComponent<Camera_Control>().enabled = false;
            transform.parent.GetComponent<Player_Movement>().enabled = false;
            //Cursor.lockState = CursorLockMode.Confined;
        }
        else{
            picked = false;
            //transform.LookAt(transform.parent.forward);
            punter.SetActive(true);
            GetComponent<Camera_Control>().enabled = true;
            transform.parent.GetComponent<Camera_Control>().enabled = true;
            transform.parent.GetComponent<Player_Movement>().enabled = true;
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }


    //public void ClearLog() {
    //    var assembly = Assembly.GetAssembly(typeof(UnityEditor.ActiveEditorTracker));
    //    var type = assembly.GetType("UnityEditorInternal.LogEntries");
    //    var method = type.GetMethod("Clear");
    //    method.Invoke(new object(), null);
    //}

}
