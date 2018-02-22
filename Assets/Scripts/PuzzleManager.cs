using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    public Transform[] pieces;
    public GameObject textPuzzle;
    public GameObject puzzlePieces;
    // Use this for initialization
    void Start () {
        
        pieces = GameObject.Find("In").transform.GetComponentsInChildren<Transform>(true);
        GameObject.Find("In").transform.parent.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
       
        
	}
    private void LateUpdate()
    {
        int count = 0;
        //print(count);
        for (int i = 0; i < pieces.Length; i++)
        {
            if (pieces[i].GetComponent<Puzzle_Rotate>() != null)
            {
                if (pieces[i].GetComponent<Puzzle_Rotate>().good)
                {
                    count++;
                }
            }
        }

        if (count == pieces.Length - 1)
        {
            puzzlePieces.SetActive(false);
            textPuzzle.SetActive(true);
        }
    }
}
