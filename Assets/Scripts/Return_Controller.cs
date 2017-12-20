using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Return_Controller : MonoBehaviour {

    private float opacity;
    private Color c;

    [SerializeField] private Transform player;
    [SerializeField] private Transform exit;
    [SerializeField] private GameObject fader;

    private bool getOut;

	// Use this for initialization
	void Start () {
        opacity = 0.0f;
        c = new Color(0, 0, 0, 0);
        getOut = false;
    }
	
	// Update is called once per frame
	void Update () {
        fader.GetComponent<Image>().color = c;

		if(Mathf.Abs(Vector3.Distance(player.position, exit.position)) <= 1.3f) {
            PlayerPrefs.SetString("SelectedCase", "Studio");
            getOut = true;
        }

        if (getOut) {
            c = new Color(c.r, c.g, c.b, opacity);
            opacity += 0.5f * Time.deltaTime;
            if (opacity >= 1.1f) {
                SceneManager.LoadScene("Loading");
            }
        }
	}
}
