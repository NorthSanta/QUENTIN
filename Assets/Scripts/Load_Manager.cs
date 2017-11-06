using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Manager : MonoBehaviour {

    protected AsyncOperation async;
    [SerializeField]
    private Text text;
    public bool isLoaded;

	// Use this for initialization
	void Start () {
        isLoaded = false;

        async = SceneManager.LoadSceneAsync(2);

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
