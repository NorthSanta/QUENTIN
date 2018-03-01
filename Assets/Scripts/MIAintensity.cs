using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIAintensity : MonoBehaviour {
    public float inten;
    float emission = 0.5f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;
        if (Input.GetKey(KeyCode.P))
        {
            emission = 1f;
        }else if (Input.GetKey(KeyCode.O))
        {
            emission = 0.5f;
        }
        Color baseColor = Color.cyan; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", finalColor);
    }
}
