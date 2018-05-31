using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementMIA : MonoBehaviour
{
    public GameObject Player;
    private Vector3 idleTilt;
    [SerializeField]
    private float idleDelay;
    [SerializeField]
    private float moveDelay;
    [SerializeField]
    public static int tutorial;
    private Coroutine lastCor;
    public Text MiaText;
    public GameObject Button;
    public GameObject MoveUpOb;
    public GameObject MapOb;
    public GameObject StandOb;
    public int indexT = -1;
    public string[] MiaVoice;
    Animator anim;
    bool moveUpPlayed;
    public static bool clicked;
    public AudioSource[] voices;
    public bool hasPlayed;
    public bool finalTutorial;
    public static bool indict;
    public GameObject map;
    public GameObject board;
    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteKey("Tutorial");
        Player = GameObject.Find("Player");
        tutorial = PlayerPrefs.GetInt("Tutorial");
        voices = GetComponents<AudioSource>();

        if(tutorial > 0)
        {
            map.tag = "Map";
            board.tag = "Map";
        }

       // print(tutorial);

        //GetComponent<Animator>().anim
        //transform.position = Camera.main.transform.position;
        //        transform.position = new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z);

    }
    IEnumerator WaitInput()
    {
        while (Input.GetMouseButtonDown(0))
        {
           
            if (lastCor != null)
            {
                StopCoroutine(lastCor);
            }
            
            MiaText.text = "";
            indexT++;
            if (indexT == 7)
            {
                MiaText.text = "    ";
                finalTutorial = true;
                Button.SetActive(false);
            }
            yield return null;
        }
    }

    IEnumerator WriteLetter(string s)
    {
        //print(s);
        foreach (char c in s.ToCharArray())
        {
            MiaText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }
    // Update is called once per frame
    void Update()
    {
        //print(indexT);
        if (tutorial == 0 && PlayerPrefs.GetString("SelectedCase") == "Studio")
        {
           
            switch (indexT)
            {
                case 0:


                    transform.position = Vector3.Lerp(transform.position, MoveUpOb.transform.position, Time.deltaTime * moveDelay);
                    StartCoroutine(WaitInput());
                    Button.SetActive(true);
                   
                    if (MiaText.text.Length == 0)
                    {
                        hasPlayed = false;
                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    if (!voices[indexT].isPlaying && !hasPlayed)
                    {
                        hasPlayed = true;
                        if (indexT == 1)
                        {
                            voices[indexT - 1].Stop();
                        }
                        voices[indexT].Play();
                    }
                    //StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    break;
                case 1:
                    transform.position = Vector3.Lerp(transform.position, MapOb.transform.position, Time.deltaTime * moveDelay);
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {
                        hasPlayed = false;
                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    if (!voices[indexT].isPlaying && !hasPlayed)
                    {
                        voices[indexT - 1].Stop();
                        voices[indexT].Play();
                        hasPlayed = true;
                    }
                    
                    break;
                case 2:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {
                        hasPlayed = false;
                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    if (!voices[indexT].isPlaying && !hasPlayed)
                    {
                        
                        hasPlayed = true;
                        voices[indexT - 1].Stop();
                        voices[indexT].Play();
                    }
                    break;
                case 3:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {
                        hasPlayed = false;
                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    if (!voices[indexT].isPlaying && !hasPlayed) 
                    {
                        hasPlayed = true;
                        voices[indexT - 1].Stop();
                        voices[indexT].Play();
                    }
                    break;
                case 4:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {
                        hasPlayed = false;
                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    if (!voices[indexT].isPlaying && !hasPlayed)
                    {
                        hasPlayed = true;
                        voices[indexT - 1].Stop();
                        voices[indexT].Play();
                    }
                    break;
                case 5:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {
                        hasPlayed = false;
                        if (indexT == 5)
                        {
                            lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                        }
                    }
                    if (!voices[indexT].isPlaying && !hasPlayed)
                    {
                        hasPlayed = true;
                        if (indexT == 5)
                        {
                            voices[indexT - 1].Stop();
                            voices[indexT].Play();
                        }
                    }
                    break;
                case 6:
                    tutorial = 1;
                    PlayerPrefs.SetInt("Tutorial", tutorial);
                    Button.SetActive(false);
                    map.tag = "Map";
                    board.tag = "Map";
                    break;
                default:
                    Button.SetActive(false);
                    break;
            }
        }
        else
        {
            if (!finalTutorial && indict && PlayerPrefs.GetString("SelectedCase") == "Studio") 
            {
                transform.position = Vector3.Lerp(transform.position, StandOb.transform.position, Time.deltaTime * moveDelay);
                StartCoroutine(WaitInput());
                Button.SetActive(true);
                if (MiaText.text.Length == 0)
                {
                    hasPlayed = false;
                    lastCor = StartCoroutine(WriteLetter(MiaVoice[6]));

                }
                if (!voices[6].isPlaying && !hasPlayed)
                {
                    hasPlayed = true;
                    //voices[5].Stop();
                    voices[6].Play();
                    tutorial++;
                    
                }

            }
            else
            {
                //print("lerf");
                idleTilt = new Vector3((Camera.main.transform.position.x - 1f), (Camera.main.transform.position.y), (Camera.main.transform.position.z));
                transform.position = Vector3.Lerp(transform.position, idleTilt, idleDelay * Time.deltaTime);
            }
           
        }

    }
}
