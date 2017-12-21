using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour {

    private float opacity;
    private Color c;
    public float speed = 6.0f;
    public Player_Interaction interact;
    public bool crouch;
    public float crouchHeight;
    public CapsuleCollider capsule;
    private GameObject fader;
    private GameObject pauseMenu;
   
    private bool firstEntry;

    // Use this for initialization
    void Start () {
        fader = GameObject.Find("Fader");
        pauseMenu = GameObject.Find("PauseMenu");
        firstEntry = true;
        opacity = 1.0f;
        c = new Color(0, 0, 0, 1);
        Cursor.lockState = CursorLockMode.Locked;
        capsule = GetComponent<CapsuleCollider>();
        interact = Camera.main.GetComponent<Player_Interaction>();
    }
  
    // Update is called once per frame
    void Update () {
        if (firstEntry) {
            fader.GetComponent<Image>().color = c;
            c = new Color(c.r, c.g, c.b, opacity);
            opacity -= 0.5f * Time.deltaTime;
            if (opacity <= 0.0f) {
                firstEntry = false;
                fader.SetActive(false);
            }
        }

        else {

            if (!interact.picked)
            {
                float deltaX = Input.GetAxis("Horizontal") * speed;
                float deltaZ = Input.GetAxis("Vertical") * speed;

                deltaX *= Time.deltaTime;
                deltaZ *= Time.deltaTime;

                transform.Translate(deltaX, 0, deltaZ);
             
                if (Input.GetKeyDown(KeyCode.LeftControl) && !crouch)
                {
                    crouch = true;
                }
                else if (Input.GetKeyUp(KeyCode.LeftControl) && crouch)
                {
                    crouch = false;
                }

                if (!crouch && capsule.height < 2)
                {
                    capsule.height += 0.1f;
                }
                else if (crouch && capsule.height > 1)
                {
                    capsule.height -= 0.1f;
                }

            }
        }
    }
}
