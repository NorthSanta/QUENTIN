using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StudioClock : MonoBehaviour {

    [SerializeField] private TextMeshPro[] hours;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        System.DateTime date1 = System.DateTime.Now;
        string final = (date1.ToString("%H") + ":" + date1.ToString("%mm"));
        for (int i = 0; i < 8; i++) {
            hours[i].SetText(final);
        }
    }
}
