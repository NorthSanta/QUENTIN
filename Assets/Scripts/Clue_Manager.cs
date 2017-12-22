using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Clue_Manager : MonoBehaviour {
    public string[] caseClues;
    public string[] clueInfo;

	// Use this for initialization
	void Start () {
        switch (SceneManager.GetActiveScene().name) {
            case "CaseOffice":
                caseClues[0] = "Somebody walks here.";
                caseClues[1] = "Keeps walking";
                caseClues[2] = "Quentin Logo.";
                break;
            default:
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
