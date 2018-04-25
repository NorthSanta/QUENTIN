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
    private int tutorial;
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
    public bool clicked;

    // Use this for initialization
    void Start()
    {
        PlayerPrefs.DeleteKey("Tutorial");
        Player = GameObject.Find("Player");
        tutorial = PlayerPrefs.GetInt("Tutorial");

        
       

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

        if (tutorial == 0)
        {
           
            switch (indexT)
            {
                case 0:


                    transform.position = Vector3.Lerp(transform.position, MoveUpOb.transform.position, Time.deltaTime * moveDelay);
                    StartCoroutine(WaitInput());
                    Button.SetActive(true);
                    if (MiaText.text.Length == 0)
                    {

                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    //StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    break;
                case 1:
                    transform.position = Vector3.Lerp(transform.position, MapOb.transform.position, Time.deltaTime * moveDelay);
                    StartCoroutine(WaitInput());

                    if (MiaText.text.Length == 0)
                    {

                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }

                    break;
                case 2:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {

                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    break;
                case 3:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {

                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    break;
                case 4:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {

                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    break;
                case 5:
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {

                        lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                    }
                    break;
                case 6:
                    transform.position = Vector3.Lerp(transform.position, StandOb.transform.position, Time.deltaTime * moveDelay);
                    StartCoroutine(WaitInput());
                    if (MiaText.text.Length == 0)
                    {
                        if (indexT < MiaVoice.Length)
                        {
                            lastCor = StartCoroutine(WriteLetter(MiaVoice[indexT]));
                        }
                    }
                    break;
                case 7:
                    tutorial = 1;
                    PlayerPrefs.SetInt("Tutorial",tutorial);
                    Button.SetActive(false);
                    break;
                default:
                    Button.SetActive(false);
                    break;
            }
        }
        else
        {
            //print("lerf");
            idleTilt = new Vector3((Camera.main.transform.position.x - 1f), (Camera.main.transform.position.y), (Camera.main.transform.position.z));
            transform.position = Vector3.Lerp(transform.position, idleTilt, idleDelay *Time.deltaTime);
        }

    }
}
