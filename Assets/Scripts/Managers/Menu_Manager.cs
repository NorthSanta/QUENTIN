using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu_Manager : MonoBehaviour {

    [SerializeField] private RectTransform Buttons;
    [SerializeField] private RectTransform Options;
    [SerializeField] private RectTransform Video;
    [SerializeField] private RectTransform Audio;
    [SerializeField] private Slider VolSlider;

    public static int myFrameRate = 30;

    //VIDEO VARIABLES
    private bool fullScreen;
    private int resX;

    //AUDIO VARIABLES
    private float vol;
    private bool mute;

    // Use this for initialization
    void Start () {
        Buttons.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
        Video.gameObject.SetActive(false);
        Audio.gameObject.SetActive(false);

        fullScreen = true;
        mute = false;

        //Set the resX
        switch (PlayerPrefs.GetInt("Res")) {
            case 540:
                resX = 960;
                break;
            case 720:
                resX = 1280;
                break;
            case 1080:
                resX = 1920;
                break;
            default:
                resX = 1280;
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

#region MenuButtons
    public void LoadGame(string name) {
        PlayerPrefs.SetString("SelectedCase","Studio");
        SceneManager.LoadScene(name);
    }

    public void EnterOptions() {
        Buttons.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
    }

    public void LoadCredits(string name) {
        SceneManager.LoadScene(name);
    }

    public void Quit() {
        Application.Quit();
    }
#endregion

#region Options
    public void EnterVideo() {
        Video.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
    }

    public void EnterAudio() {
        Audio.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
    }

    public void BackOptions() {
        Buttons.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
    }
#endregion

#region Video
    public void Resolution(int res) {
        switch (res) {
            case 1080:
                resX = 1920;
                break;
            case 720:
                resX = 1280;
                break;
            case 540:
                resX = 960;
                break;
            default:
                break;
        }
        PlayerPrefs.SetInt("Res", res);
        Screen.SetResolution(resX, res, fullScreen);
    }

    public void FPSLimit(int limit) {
        PlayerPrefs.SetInt("Fps", limit);
        Screen.SetResolution(resX, PlayerPrefs.GetInt("Res"), fullScreen, PlayerPrefs.GetInt("Fps"));
    }

    public void VSync(int active) {
        PlayerPrefs.SetInt("VSync", active);
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
    }

    public void AntiAliasing(int aa) {
        PlayerPrefs.SetInt("AA", aa);
        QualitySettings.antiAliasing = PlayerPrefs.GetInt("AA");
    }

    public void BackVideo() {
        Video.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
    }
#endregion

#region Audio
    public void Mute() {
        if (mute) {
            PlayerPrefs.SetInt("Mute", 0);
            AudioListener.volume = vol;
            mute = false;
        }
        else {
            PlayerPrefs.SetInt("Mute", 1);
            AudioListener.volume = 0.0f;
            mute = true;
        }
    }

    public void Volume() {
        vol = VolSlider.value;
        AudioListener.volume = vol;
        PlayerPrefs.SetFloat("Vol", vol);
    }

    public void BackAudio() {
        Audio.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
    }
    #endregion

#region SocialMedia
    public void GoURL(string name) {
        Application.OpenURL(name);
    }
#endregion

}
