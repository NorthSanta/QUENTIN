using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_Manager : MonoBehaviour {

    public static int myFrameRate = 30;

    //Async Operator for preload scene
    protected AsyncOperation async;

    void Awake() {
        PlayerPrefs.SetInt("Fps", 30);
        PlayerPrefs.SetInt("Res", 720);
        PlayerPrefs.SetInt("VSync", 0);
        PlayerPrefs.SetInt("AA", 0);

        PlayerPrefs.SetFloat("Vol", 1.0f);
        PlayerPrefs.SetInt("Mute", 0);

        PlayerPrefs.SetInt("Character", 0);
        PlayerPrefs.SetInt("Map", 0);


        //Set the current frameRate
        Application.targetFrameRate = myFrameRate;
    }

    // Use this for initialization
    void Start () {
        //Configuration
        switch (PlayerPrefs.GetInt("Res")) {
            case 540:
                Screen.SetResolution(960, 540, true, PlayerPrefs.GetInt("Fps"));
                break;
            case 720:
                Screen.SetResolution(1280, 720, true, PlayerPrefs.GetInt("Fps"));
                break;
            case 1080:
                Screen.SetResolution(1920, 1080, true, PlayerPrefs.GetInt("Fps"));
                break;
        }

        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
        QualitySettings.antiAliasing = PlayerPrefs.GetInt("AA");
        if (PlayerPrefs.GetInt("Mute") == 1) AudioListener.volume = 0.0f;
        else AudioListener.volume = PlayerPrefs.GetFloat("Vol");

        //Pre Load the menu scene for smooth transition
        async = SceneManager.LoadSceneAsync("Menu Scene");
        //Set the activation on full load on false
        async.allowSceneActivation = false;

        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
		//TODO
	}
}
