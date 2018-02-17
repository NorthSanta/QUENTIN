using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Clue_Manager : MonoBehaviour {
    public string[] caseClues;
    public string[] clueInfo;
    public List<int> solution;

	// Use this for initialization
	void Start () {
        switch (SceneManager.GetActiveScene().name) {
            case "CaseOffice":
                caseClues[0] = "Somebody walks here.";
                caseClues[1] = "Keeps walking.";
                caseClues[2] = "Quentin Logo.";
                break;
            default:
                //caseClues[0] = "";
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        //string s = Camera.main.GetComponent<Studio_Interaction>().activeCase.gameObject.name;
        //if (s != Camera.main.GetComponent<Studio_Interaction>().activeCase.gameObject.name) {
        //    switch (Camera.main.GetComponent<Studio_Interaction>().activeCase.gameObject.name)
        //    {
        //        case "CaseOffice":
        //            for(int i = 0; i < 3; i++)
        //            {
        //                solution.Add(i);
        //            }
        //            break;
        //    }
        //}
	}
}
