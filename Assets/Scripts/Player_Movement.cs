using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed = 6.0f;
    public Player_Interaction interact;
    public bool crouch;
    public float crouchHeight;
    public CapsuleCollider capsule;

    // Use this for initialization
    void Start () {
      
        Cursor.lockState = CursorLockMode.Locked;
        capsule = GetComponent<CapsuleCollider>();
        interact = Camera.main.GetComponent<Player_Interaction>();
        
    }
  
    // Update is called once per frame
    void Update () {

        if (!interact.picked)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
           
            deltaX *= Time.deltaTime;
            deltaZ *= Time.deltaTime;
            
            transform.Translate(deltaX, 0, deltaZ);
            if (Input.GetKeyDown("escape"))
            {
                Cursor.lockState = CursorLockMode.None;
            }
            if(Input.GetKeyDown(KeyCode.LeftControl) && !crouch)
            {           
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) && crouch)
            {
                crouch = false;
            }

            if(!crouch && capsule.height < 2)
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
