using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Clue_Manager : MonoBehaviour {
    public string[] caseClues;
    public string[] clueInfo;
    public static List<int> solution = new List<int>();

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 6; i++)
        {
            solution.Add(i);
        }
        switch (SceneManager.GetActiveScene().name) {
            case "CaseOffice":
                caseClues[0] = "Somebody walks here.";
                caseClues[1] = "Blood on the mop.";
                caseClues[2] = "Mr. M.";
                caseClues[3] = "Blood Stains.";
                caseClues[4] = "Cleaning TimeTable";
                caseClues[6] = "Quentin Alpha Logo.";
                break;
            default:
                //caseClues[0] = "";
                break;
        }
    }

    // Update is called once per frame
    void Update() {


       
       
        
	}
}
