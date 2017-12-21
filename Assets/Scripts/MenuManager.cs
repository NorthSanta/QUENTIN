using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseMenu;
    private GameObject player;
    public Text text;
    private Clue_Manager clue_manager;
    public GameObject Game;
    public GameObject Op;
    public GameObject Clues;
    public GameObject Tips;

    public GameObject buttons;
    public Image icon;
    public Camera canvasCam;

    public Player_Interaction interact;

    public bool inMenu;
    // Use this for initialization
    void Start()
    {
     
        //pauseMenu = GameObject.Find("PauseMenu");
        player = GameObject.Find("Player");
        clue_manager = GetComponent<Clue_Manager>();
        inMenu = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("escape"))
        {

            if (inMenu)
            {
                //Cursor.lockState = CursorLockMode.Confined;

                inMenu = false;
                interact.picked = false;
            }
            else if (!inMenu && !interact.picked)
            {
                //Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                Cursor.visible = false;
                inMenu = true;
                interact.picked = true;
            }
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            player.GetComponent<Player_Movement>().enabled = !player.GetComponent<Player_Movement>().enabled;
            player.GetComponent<Camera_Control>().enabled = !player.GetComponent<Camera_Control>().enabled;
            Camera.main.GetComponent<Camera_Control>().enabled = !Camera.main.GetComponent<Camera_Control>().enabled;


        }


    }

    public void OptionsMenu()
    {
        text.text = "";
        Op.SetActive(true);
        Game.SetActive(false);
        Clues.SetActive(false);
        Tips.SetActive(false);
    }
    public void GameMenu()
    {
        text.text = "";
        Game.SetActive(true);
        Op.SetActive(false);
        Clues.SetActive(false);
        Tips.SetActive(false);
    }
    public void CluesMenu()
    {
        text.text = "";
        Clues.SetActive(true);
        Game.SetActive(false);
        Op.SetActive(false);
        Tips.SetActive(false);

        for (int i = 0; i < clue_manager.caseClues.Length; i++)
        {
            if (PlayerPrefs.GetString("office" + i) != "")
            {
                text.text += (i + 1) + "." + PlayerPrefs.GetString("office" + i) + "\n";
            }
        }
    }
    public void TipsMenu()
    {
        text.text = "";
        Tips.SetActive(true);
        Game.SetActive(false);
        Op.SetActive(false);
        Clues.SetActive(false);
    }

    public void resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        inMenu = false;
        interact.picked = false;
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        player.GetComponent<Player_Movement>().enabled = !player.GetComponent<Player_Movement>().enabled;
        player.GetComponent<Camera_Control>().enabled = !player.GetComponent<Camera_Control>().enabled;
        Camera.main.GetComponent<Camera_Control>().enabled = !Camera.main.GetComponent<Camera_Control>().enabled;
    }
    public void clues()
    {

    }
}
