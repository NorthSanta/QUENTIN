using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void loadScene(string name) {
        PlayerPrefs.SetString("SelectedCase","Studio");
        SceneManager.LoadScene(name);
    }

    public void quit() {
        Application.Quit();
    }
}
