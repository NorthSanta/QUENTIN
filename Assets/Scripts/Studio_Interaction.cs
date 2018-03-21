using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Studio_Interaction : MonoBehaviour {

    //Raycast for mouse
    private RaycastHit hit;
    private Ray ray;

    //All the Assets
    [SerializeField] private GameObject door;

    [SerializeField] private GameObject map;
    [SerializeField] private GameObject board;
    [SerializeField]
    private GameObject axis;
    [SerializeField]
    private GameObject AxisBoard;

    [SerializeField] private GameObject caseName;
    [SerializeField] private GameObject caseImage;
    [SerializeField] private GameObject caseDescription;

    [SerializeField] private GameObject caseAccept;
    [SerializeField] private GameObject caseCancel;

    [SerializeField]
    private GameObject MapUI;
    [SerializeField]
    private GameObject BoardUI;

    public Transform[] mapCases;

    public Transform[] nameCases;
    public Transform[] imageCases;
    public Transform[] desCases;

    public Transform activeCase;
    public Transform selectedCase;

    //Enablers
    public bool mapEnabled;
    public bool boardEnabled;
    public bool doorOpen;

    //Navigators
    public int mapIndex;
    public int boardIndex;

    //Guarrada
    //private double counter;
    private Animator animGirar;

    // Use this for initialization
    void Start () {
        //This take all the cases on a Transform Array
        mapCases = map.transform.GetComponentsInChildren<Transform>(true); //Element 0 is the parent
        nameCases = caseName.transform.GetComponentsInChildren<Transform>(true); //Element 0 is the parent
        imageCases = caseImage.transform.GetComponentsInChildren<Transform>(true); //Element 0 is the parent
        desCases = caseDescription.transform.GetComponentsInChildren<Transform>(true); //Element 0 is the parent
        activeCase = mapCases[1];

        //The map and board cannot used
        mapEnabled = false;
        boardEnabled = false;
        doorOpen = false;

        //Init Index to 1
        mapIndex = 1;
        boardIndex = 0;

        //Init the Guarrada (every unit is 1 sec)
        //counter = 0.0f; 
        animGirar = board.GetComponent<Animator>();

        
    }
	
	// Update is called once per frame
	void Update () {
        //The mopuse raycast
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Debug.DrawRay(transform.position, Input.mousePosition * 1.5f, Color.red);

        //The Input of the player
        HandleInput();

        //Print the map cases on scene & accept/cancel
        if (mapEnabled && !boardEnabled) {
            Camera.main.transform.parent.position = new Vector3(-0.5857f, 1.5f, -0.5630f);
            Quaternion q = Quaternion.Euler(Camera.main.transform.parent.rotation.ToEuler().x, -152.754f, 0);
            //print(axis.transform.rotation.y);
            Camera.main.transform.parent.rotation = q;

            MapUI.SetActive(true);
            BoardUI.SetActive(false);
            for (int i = 1; i < mapCases.Length; i++) {
                mapCases[i].gameObject.SetActive(true);
                mapCases[i].GetComponent<BoxCollider>().enabled = true;
            }
            mapCases[0].GetComponent<BoxCollider>().enabled = false;
            board.GetComponent<BoxCollider>().enabled = false;
        }
        else if (mapEnabled && boardEnabled) {
            BoardUI.SetActive(true);
            MapUI.SetActive(false);
            // Camera.main.transform.parent.position = AxisBoard.transform.position;
            //
            // Camera.main.transform.rotation = Quaternion.Lerp(transform.rotation, AxisBoard.transform.rotation, Time.time);
            if (selectedCase == null)
            {
                caseAccept.gameObject.SetActive(true);
                caseCancel.gameObject.SetActive(true);
            }
            
        }
        else{
            /*for (int i = 1; i < mapCases.Length; i++) {
                mapCases[i].gameObject.SetActive(false);
            }*/
            mapCases[0].GetComponent<BoxCollider>().enabled = true;
            board.GetComponent<BoxCollider>().enabled = true;
            caseAccept.gameObject.SetActive(false);
            caseCancel.gameObject.SetActive(false);
            MapUI.SetActive(false);
            BoardUI.SetActive(false);
        }

        //Change the Board Info depending to the activeCase
        switch (activeCase.gameObject.name) {
            case "CaseOffice":
                for(int i = 1; i < mapCases.Length; i++) {
                    if (i == 1) {
                        nameCases[i].gameObject.SetActive(true);
                        imageCases[i].gameObject.SetActive(true);
                        desCases[i].gameObject.SetActive(true);
                    }
                    else {
                        nameCases[i].gameObject.SetActive(false);
                        imageCases[i].gameObject.SetActive(false);
                        desCases[i].gameObject.SetActive(false);
                    }
                }
                break;
            case "Case2":
                for (int i = 1; i < mapCases.Length; i++) {
                    if (i == 2) {
                        nameCases[i].gameObject.SetActive(true);
                        imageCases[i].gameObject.SetActive(true);
                        desCases[i].gameObject.SetActive(true);
                    }
                    else {
                        nameCases[i].gameObject.SetActive(false);
                        imageCases[i].gameObject.SetActive(false);
                        desCases[i].gameObject.SetActive(false);
                    }
                }
                break;
            case "Case3":
                for (int i = 1; i < mapCases.Length; i++) {
                    if (i == 3) {
                        nameCases[i].gameObject.SetActive(true);
                        imageCases[i].gameObject.SetActive(true);
                        desCases[i].gameObject.SetActive(true);
                    }
                    else {
                        nameCases[i].gameObject.SetActive(false);
                        imageCases[i].gameObject.SetActive(false);
                        desCases[i].gameObject.SetActive(false);
                    }
                }
                break;
            case "Case4":
                for (int i = 1; i < mapCases.Length; i++) {
                    if (i == 4) {
                        nameCases[i].gameObject.SetActive(true);
                        imageCases[i].gameObject.SetActive(true);
                        desCases[i].gameObject.SetActive(true);
                    }
                    else {
                        nameCases[i].gameObject.SetActive(false);
                        imageCases[i].gameObject.SetActive(false);
                        desCases[i].gameObject.SetActive(false);
                    }
                }
                break;
            case "Case5":
                for (int i = 1; i < mapCases.Length; i++) {
                    if (i == 5) {
                        nameCases[i].gameObject.SetActive(true);
                        imageCases[i].gameObject.SetActive(true);
                        desCases[i].gameObject.SetActive(true);
                    }
                    else {
                        nameCases[i].gameObject.SetActive(false);
                        imageCases[i].gameObject.SetActive(false);
                        desCases[i].gameObject.SetActive(false);
                    }
                }
                break;
            default:
                //TODO
                break;
        }


        if (doorOpen) {
            PlayerPrefs.SetString("SelectedCase", selectedCase.name);
            door.gameObject.tag = "Door";
        }

	}

    //Input Function
    void HandleInput() {
        //The input when the MAP is enabled
        if (mapEnabled && !boardEnabled) {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animGirar.SetBool("girar", !animGirar.GetBool("girar"));
            }
            //MOUSE INPUT
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                if (Physics.Raycast(ray, out hit)) {
                    switch (hit.transform.name) {
                        case "CaseOffice":
                            mapIndex = 1;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case2":
                            mapIndex = 2;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case3":
                            mapIndex = 3;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case4":
                            mapIndex = 4;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case5":
                            mapIndex = 5;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        default:
                            break;
                    }
                }

                if (Input.GetKeyUp(KeyCode.Escape))
                {
                    boardIndex = 0;
                    boardEnabled = false;
                    mapEnabled = false;
                }
            }

            //KEYBOARD INPUT
            /*if (Input.GetKeyUp(KeyCode.UpArrow)) if (mapIndex > 1) mapIndex--;
            if (Input.GetKeyUp(KeyCode.DownArrow)) if (mapIndex < mapCases.Length - 1) mapIndex++;
            if (Input.GetKeyUp(KeyCode.Return)) {
                activeCase = mapCases[mapIndex];
                mapEnabled = false;
                boardEnabled = true;
                counter = Time.timeSinceLevelLoad + 0.5;
            }
            if (Input.GetKeyUp(KeyCode.Escape)) {
                mapEnabled = false;
                Cursor.visible = false;
            }*/
        }

        //The input when the BOARD is enabled
        if (mapEnabled && boardEnabled) {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                animGirar.SetBool("girar", !animGirar.GetBool("girar"));
            }
            Cursor.visible = false;
            //MOUSE INPUT
            if (Input.GetKeyUp(KeyCode.Mouse0)) {
                if (Physics.Raycast(ray, out hit)) {
                    switch (hit.transform.name) {
                        case "CaseOffice":
                            mapIndex = 1;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case2":
                            mapIndex = 2;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case3":
                            mapIndex = 3;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case4":
                            mapIndex = 4;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "Case5":
                            mapIndex = 5;
                            activeCase = mapCases[mapIndex];
                            boardEnabled = true;
                            break;
                        case "CaseAccept":
                            selectedCase = activeCase;
                            boardEnabled = false;
                            mapEnabled = false;
                            doorOpen = true;
                            break;
                        case "CaseCancel":
                            boardEnabled = false;
                            mapEnabled = false;
                            break;
                        default:
                            break;
                    }
                }
            }

            //KEYBOARD INPUT
            /*if (Input.GetKeyUp(KeyCode.RightArrow)) if (boardIndex == 0) boardIndex = 1;
            if (Input.GetKeyUp(KeyCode.LeftArrow)) if (boardIndex == 1) boardIndex = 0;
            if (Input.GetKeyUp(KeyCode.Return) && counter < Time.timeSinceLevelLoad) {
                if (boardIndex == 0) {
                    selectedCase = activeCase;
                    boardEnabled = false;
                    mapEnabled = false;
                    doorOpen = true;
                }
                else {
                    boardIndex = 0;
                    boardEnabled = false;
                    mapEnabled = true;
                }
            }*/
        }

        if (Input.GetKeyUp(KeyCode.Escape)) {
            boardIndex = 0;
            boardEnabled = false;
            mapEnabled = false;
        }
    }

}
