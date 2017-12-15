using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Manager : MonoBehaviour {

    protected AsyncOperation async;

    [SerializeField]
    private Text text;

    [SerializeField]
    private GameObject printableInfo;

    private Transform[] caseInfo;

    public bool isLoaded;

	// Use this for initialization
	void Start () {
        isLoaded = false;

        //Fill the array with all the printables cases.
        caseInfo = printableInfo.transform.GetComponentsInChildren<Transform>(true); //Element 0 is the parent
        
        //Active the correct info depending on the case
        for (int i = 1; i < caseInfo.Length; i++){
            if (caseInfo[i].name == PlayerPrefs.GetString("SelectedCase")) caseInfo[i].gameObject.SetActive(true);
        }

        async = SceneManager.LoadSceneAsync(PlayerPrefs.GetString("SelectedCase"));
   
        //Set the activation on full load on false
        async.allowSceneActivation = false;  

        Cursor.visible = false;

    }
	
	// Update is called once per frame
	void Update () {
        print(async.progress);
        if (async.progress >= 0.89) isLoaded = true;

        if (isLoaded) text.text = "PRESS ANY KEY";

        if (isLoaded && Input.anyKey) async.allowSceneActivation = true;

    }
}
