using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_Manager : MonoBehaviour {

    public static int myFrameRate = 30;

    private float introCounter = 0.0f;

    [SerializeField] private Animator donkeyLogo;
    [SerializeField] private Animator quentinLogo;
    [SerializeField] private Animator unityLogo;
    [SerializeField] private Animator dsLogo;
    [SerializeField] private Animator text;

    //Async Operator for preload scene
    protected AsyncOperation async;

    void Awake() {
        if (PlayerPrefs.GetInt("FirstEntry") == 0) { }
        else {
            PlayerPrefs.SetInt("FullScreen", 0);
            PlayerPrefs.SetInt("Fps", 30);
            PlayerPrefs.SetInt("Res", 720);
            PlayerPrefs.SetInt("VSync", 0);
            PlayerPrefs.SetInt("AA", 0);

            PlayerPrefs.SetFloat("Vol", 1.0f);
            PlayerPrefs.SetInt("Mute", 0);

            PlayerPrefs.SetInt("Character", 0);
            PlayerPrefs.SetInt("Map", 0);

            PlayerPrefs.SetInt("FirstEntry", 0);
        }
        
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
        async = SceneManager.LoadSceneAsync("Menu");
        //Set the activation on full load on false
        async.allowSceneActivation = false;
        
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        //TODO
        introCounter += Time.deltaTime;
        if (introCounter >= 1.0f && introCounter <= 2.0f) donkeyLogo.SetBool("Active", true);

        else if (introCounter >= 5.99f && introCounter <= 8.99f) quentinLogo.SetBool("Active", true);

        else if (introCounter >= 10.99f && introCounter <= 11.99f) {
            unityLogo.GetComponent<Animator>().SetBool("Active", true);
            dsLogo.GetComponent<Animator>().SetBool("Active", true);
            text.GetComponent<Animator>().SetBool("Active", true);
        }

        if (introCounter >= 16.50 && introCounter <= 17.50) async.allowSceneActivation = true;
    }
}
