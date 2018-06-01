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
    [SerializeField] private RectTransform PressStart;
    [SerializeField] private Animator CameraAnim;
    [SerializeField] private Transform NoteBookOpen;
    [SerializeField] private RectTransform ButtonsMark;
    [SerializeField] private RectTransform[] OptionsMark;
    [SerializeField] private RectTransform[] VideoMark;

    public static int myFrameRate = 30;

    //VIDEO VARIABLES
    private bool fullScreen;
    private int resX;

    //AUDIO VARIABLES
    private float vol;
    private bool mute;

    private float timer;
    private bool start;
    private bool showed;
    private bool videoActive;

    // Use this for initialization
    void Start () {
        Buttons.gameObject.SetActive(false);
        Options.gameObject.SetActive(false);
        Video.gameObject.SetActive(false);
        Audio.gameObject.SetActive(false);
        PressStart.gameObject.SetActive(false);

        fullScreen = true;
        mute = false;

        timer = 0.0f;
        start = false;
        showed = false;
        videoActive = false;

        
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

        Cursor.visible = true;
        AudioListener.volume = VolSlider.value/100;
        PlayerPrefs.SetFloat("Vol", VolSlider.value / 100);
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(timer >= 5.0f && !start) {
            PressStart.gameObject.SetActive(true);
            if (Input.anyKey) {
                start = true;
                timer = 0.0f;
                CameraAnim.SetBool("start", true);
                PressStart.gameObject.SetActive(false);
            }
        }

        if (start && timer >= 2.0f && !showed) {
            PressStart.gameObject.SetActive(false);
            Buttons.gameObject.SetActive(true);
            NoteBookOpen.gameObject.SetActive(true);
            showed = true;
        }

        RenderVideo();
        //Debugg();
	}

#region MenuButtons
    public void LoadGame(string name) {
        PlayerPrefs.SetString("SelectedCase","Studio");
        SceneManager.LoadScene(name);
    }

    public void EnterOptions() {
        Buttons.gameObject.SetActive(false);
        Options.gameObject.SetActive(true);
        ButtonsMark.gameObject.SetActive(true);
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
        videoActive = true;
        Audio.gameObject.SetActive(false);
        OptionsMark[0].gameObject.SetActive(true);
        OptionsMark[1].gameObject.SetActive(false);
    }

    public void EnterAudio() {
        Audio.gameObject.SetActive(true);
        Video.gameObject.SetActive(false);
        videoActive = false;
        OptionsMark[1].gameObject.SetActive(true);
        OptionsMark[0].gameObject.SetActive(false);
    }

    public void BackOptions() {
        Buttons.gameObject.SetActive(true);
        Options.gameObject.SetActive(false);
        Audio.gameObject.SetActive(false);
        Video.gameObject.SetActive(false);
        videoActive = false;
        ButtonsMark.gameObject.SetActive(false);
        OptionsMark[0].gameObject.SetActive(false);
        OptionsMark[1].gameObject.SetActive(false);
    }
#endregion

#region Video
    public void Resolution(int res) {
        PlayerPrefs.SetInt("Res", res);
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
        Screen.SetResolution(resX, res, fullScreen);
    }

    public void FPSLimit(int limit) {
        PlayerPrefs.SetInt("Fps", limit);
        Screen.SetResolution(resX, PlayerPrefs.GetInt("Res"), fullScreen, PlayerPrefs.GetInt("Fps"));
        Application.targetFrameRate = PlayerPrefs.GetInt("Fps");
    }

    public void VSync(int active) {
        PlayerPrefs.SetInt("VSync", active);
        QualitySettings.vSyncCount = PlayerPrefs.GetInt("VSync");
    }

    public void AntiAliasing(int aa) {
        PlayerPrefs.SetInt("AA", aa);
        QualitySettings.antiAliasing = PlayerPrefs.GetInt("AA");
    }
#endregion

#region Audio
    public void Mute() {
        if (mute) {
            PlayerPrefs.SetInt("Mute", 0);
            AudioListener.volume = VolSlider.value / 100;
            mute = false;
        }
        else {
            PlayerPrefs.SetInt("Mute", 1);
            AudioListener.volume = 0;
            mute = true;
        }
    }

    public void Volume() {
        if (!mute)
        {
            vol = VolSlider.value / 100;
            AudioListener.volume = vol;
            PlayerPrefs.SetFloat("Vol", vol);
        }
    }
    #endregion

#region SocialMedia
    public void GoURL(string name) {
        Application.OpenURL(name);
    }
#endregion

    public void RenderVideo() {
        if (Video.gameObject.active) {
            switch (PlayerPrefs.GetInt("Res"))
            {
                case 1080:
                    resX = 1920;
                    VideoMark[0].gameObject.SetActive(true);
                    VideoMark[1].gameObject.SetActive(false);
                    VideoMark[2].gameObject.SetActive(false);
                    break;
                case 720:
                    resX = 1280;
                    VideoMark[1].gameObject.SetActive(true);
                    VideoMark[0].gameObject.SetActive(false);
                    VideoMark[2].gameObject.SetActive(false);
                    break;
                case 540:
                    resX = 960;
                    VideoMark[2].gameObject.SetActive(true);
                    VideoMark[0].gameObject.SetActive(false);
                    VideoMark[1].gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            switch (PlayerPrefs.GetInt("Fps"))
            {
                case 30:
                    VideoMark[5].gameObject.SetActive(true);
                    VideoMark[3].gameObject.SetActive(false);
                    VideoMark[4].gameObject.SetActive(false);
                    break;
                case 60:
                    VideoMark[4].gameObject.SetActive(true);
                    VideoMark[3].gameObject.SetActive(false);
                    VideoMark[5].gameObject.SetActive(false);
                    break;
                case 120:
                    VideoMark[3].gameObject.SetActive(true);
                    VideoMark[4].gameObject.SetActive(false);
                    VideoMark[5].gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            switch (PlayerPrefs.GetInt("VSync"))
            {
                case 0:
                    VideoMark[6].gameObject.SetActive(true);
                    VideoMark[7].gameObject.SetActive(false);
                    break;
                case 1:
                    VideoMark[7].gameObject.SetActive(true);
                    VideoMark[6].gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
            switch (PlayerPrefs.GetInt("AA"))
            {
                case 0:
                    VideoMark[8].gameObject.SetActive(true);
                    VideoMark[9].gameObject.SetActive(false);
                    VideoMark[10].gameObject.SetActive(false);
                    VideoMark[11].gameObject.SetActive(false);
                    break;
                case 2:
                    VideoMark[9].gameObject.SetActive(true);
                    VideoMark[8].gameObject.SetActive(false);
                    VideoMark[10].gameObject.SetActive(false);
                    VideoMark[11].gameObject.SetActive(false);
                    break;
                case 4:
                    VideoMark[10].gameObject.SetActive(true);
                    VideoMark[8].gameObject.SetActive(false);
                    VideoMark[9].gameObject.SetActive(false);
                    VideoMark[11].gameObject.SetActive(false);
                    break;
                case 8:
                    VideoMark[11].gameObject.SetActive(true);
                    VideoMark[8].gameObject.SetActive(false);
                    VideoMark[9].gameObject.SetActive(false);
                    VideoMark[10].gameObject.SetActive(false);
                    break;
                default:
                    break;
            }
        }
        else {
            for (int i = 0; i < 12; i++) {
                VideoMark[i].gameObject.SetActive(false);
            }
        }
    }

    public void Debugg()
    {
        print(PlayerPrefs.GetInt("Res"));
        print(PlayerPrefs.GetInt("Fps"));
        print(PlayerPrefs.GetInt("VSync"));
        print(PlayerPrefs.GetInt("AA"));

    }

}
