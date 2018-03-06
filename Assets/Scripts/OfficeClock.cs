using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OfficeClock : MonoBehaviour {

    [SerializeField] private TextMeshPro hours;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        System.DateTime date1 = System.DateTime.Now;
        string finalDate = "06/30/2035 ";
        string finalH = (date1.ToString("%HH") + ":" + date1.ToString("%mm"));
        hours.SetText(finalDate + finalH);
    }
}
