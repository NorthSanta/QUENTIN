using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed = 6.0f;
    public Player_Interaction interact;
    public bool crouch;
    public float crouchHeight;
    public CapsuleCollider capsule;
    //private CharacterController _charCont;
    // Use this for initialization
    void Start () {
        //_charCont = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        capsule = GetComponent<CapsuleCollider>();
        interact = Camera.main.GetComponent<Player_Interaction>();
        
    }

    
    // Update is called once per frame
    void Update () {
        //float deltaX = Input.GetAxis("Horizontal") * speed;
        //float deltaZ = Input.GetAxis("Vertical") * speed;

        //Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //movement = Vector3.ClampMagnitude(movement, speed);

        //movement *= Time.deltaTime;
        //movement = transform.TransformDirection(movement);

        //_charCont.Move(movement);
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
                

                //transform.position = new Vector3(transform.position.x, crouchHeight / 1.5f, transform.position.z);
                //this.GetComponent<CapsuleCollider>(). -= Vector3(0, crouchDeltaHeight, 0);
                //capsule.height -= crouchHeight;
                //crouching = true;
                crouch = true;
            }
            else if (Input.GetKeyUp(KeyCode.LeftControl) && crouch)
            {
                //float step = 1 * Time.deltaTime;
                //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, crouchHeight, transform.position.z), 0.1f);
                //transform.position = new Vector3(transform.position.x, crouchHeight, transform.position.z);
                //capsule.height += crouchHeight;
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
