using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMIA : MonoBehaviour {
    public GameObject Player;
    private Vector3 idleTilt;
    [SerializeField]
    private float idleDelay;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
        transform.position = Camera.main.transform.position;
        transform.position = new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        idleTilt = new Vector3((Camera.main.transform.position.x - 1f), (Camera.main.transform.position.y), (Camera.main.transform.position.z));
        transform.position = Vector3.Lerp(transform.position, idleTilt, idleDelay);
    }
}
