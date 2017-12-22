﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Reflection;


public class Player_Interaction : MonoBehaviour
{
    RaycastHit interact;
    public bool canPick;
    public bool interactuable;
    public bool picked;
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
    private float interactDistance;

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
        
        //myCanvas = GameObject.Find("trueCanvas");
        //Cursor.visible = false;
        //myCanvas.SetActive(false);
        //ppProfile = Camera.main.GetComponent<PostProcessingProfile>();
    }

    // Update is called once per frame
    void Update() {
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
                        transform.parent.position = new Vector3(-0.5857f, 1.5f, -0.5630f);
                        transform.parent.rotation = new Quaternion(0.0f, 1.0f, 0.0f, -0.24f);
                        transform.rotation.Set(0.0f, 1.0f, -0.05f, -0.24f);// = new Quaternion(0.0f, 1.0f, -0.05f, -0.24f);
                                                                           //transform.parent.eulerAngles = new Vector3(0, -0.5630f, 0);
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
                    col = interact.collider;
                    interactuable = true;
                    if (Input.GetKeyDown(KeyCode.E)) {
                        if (!interact.collider.gameObject.GetComponent<Clue_Index>().found) {
                            indexClue = interact.collider.gameObject.GetComponent<Clue_Index>().clueIndex;
                            textPista.GetComponent<Text>().text = manager.caseClues[indexClue];
                            PlayerPrefs.SetString("office" + cluesFound++, manager.caseClues[indexClue]);
                            interact.collider.gameObject.GetComponent<Clue_Index>().found = true;
                            //textPista.GetComponent<Text>().text = PlayerPrefs.GetString("office" + indexClue);
                            llibreta.SetActive(true);
                            textPista.SetActive(true);
                        }
                    }
                    //canPick = true;
                    break;
                case "Puzzle":
                    interactuable = true;
                    if (Input.GetKeyDown(KeyCode.E)) {
                        puzzleProg.SetActive(!puzzleProg.activeSelf);
                        punter.SetActive(false);
                        lupa.SetActive(false);
                        GetComponent<Camera_Control>().enabled = false;
                        transform.parent.GetComponent<Camera_Control>().enabled = false;
                        transform.parent.GetComponent<Player_Movement>().enabled = false;
                        Cursor.lockState = CursorLockMode.None;
                    }else if (Input.GetKeyDown(KeyCode.R)) {
                        GetComponent<Camera_Control>().enabled = true;
                        transform.parent.GetComponent<Camera_Control>().enabled = true;
                        transform.parent.GetComponent<Player_Movement>().enabled = true;
                        Cursor.lockState = CursorLockMode.Locked;
                    }
                    break;
                default:
                    canPick = false;
                    interactuable = false;
                    break;
            }
        }
        else
        {
            interactuable = false;
            canPick = false;
        }



        if (canPick && Input.GetKeyDown(KeyCode.E) && !picked){
            buttons.SetActive(true);
            ppProfile.depthOfField.enabled = true;
            ppProfile.vignette.enabled = true;

            //Camera.main.GetComponent<PostProcessingProfile>().depthOfField.settings = ppProfile.depthOfField.settings;
            //Cursor.SetCursor(mouse, Vector2.zero, CursorMode.Auto);
            Cursor.lockState = CursorLockMode.None;

            vell = interact.collider.gameObject;
            vell.SetActive(false);
            nou = (GameObject)Instantiate(interact.collider.gameObject);
            GameObject copy = (GameObject)Instantiate(interact.collider.gameObject);
            nou.SetActive(true);
            nou.layer = 4;
            //nou.GetComponent<GlowObject>().enabled = false;
            if (col.GetType() == typeof(BoxCollider))
            {
                nou.GetComponent<BoxCollider>().enabled = false;
                copy.GetComponent<BoxCollider>().enabled = false;
            }
            else if (col.GetType() == typeof(MeshCollider))
            {
                nou.GetComponent<MeshCollider>().enabled = false;
                copy.GetComponent<MeshCollider>().enabled = false;
            }

            
            nou.transform.parent = buttons.transform.parent;
            nou.transform.SetAsFirstSibling();
            nou.transform.localPosition = new Vector3(0, 0, 0);
            nou.transform.rotation = new Quaternion(0, 0, 0, 0);
            nou.AddComponent<Object_Movement>();
            nou.GetComponent<Object_Movement>().alpha = 100;
            nou.AddComponent<rot_Obj>();
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
        else if (picked && Input.GetKeyDown(KeyCode.E)){
            UV.SetActive(false);
            Polvos.SetActive(false);
            ADN.SetActive(false);
            buttons.SetActive(false);
            ppProfile.depthOfField.enabled = false;
            ppProfile.vignette.enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            //panel.SetActive(false);
            vell.SetActive(true);
            Destroy(nou);
            picked = false;
        }

        if (picked){
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(buttons.transform.parent.transform as RectTransform, Input.mousePosition, canvasCam, out pos);
            icon.transform.position = buttons.transform.parent.transform.TransformPoint(pos);
        }
        else{
           
            icon.transform.localPosition = new Vector3(0, 0, 0);
        }

    }

    void lookMap(bool enabled) {
        
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
