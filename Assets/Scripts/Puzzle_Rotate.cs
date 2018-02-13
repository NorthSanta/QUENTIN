using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_Rotate : MonoBehaviour {

    public float smooth = 1f;
    private Quaternion targetRotation;
    void Start()
    {
        targetRotation = transform.rotation;
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        gameObject.GetComponent<Button>().onClick.AddListener(clicked);
    }
    void OnMouseDown()
    {
        
        
    }
    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10 * smooth * Time.deltaTime);
    }
    public void clicked()
    {
        //Debug.Log("In");
        targetRotation *= Quaternion.AngleAxis(-90, Vector3.forward);
    }
}
