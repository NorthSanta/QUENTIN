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
        for (int i = 0; i < 3; i++)
        {
            solution.Add(i);
        }
        switch (SceneManager.GetActiveScene().name) {
            case "CaseOffice":
                caseClues[0] = "Somebody walks here.";
                caseClues[1] = "Keeps walking.";
                caseClues[2] = "Quentin Logo.";
                caseClues[3] = "Mr. M.";
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
