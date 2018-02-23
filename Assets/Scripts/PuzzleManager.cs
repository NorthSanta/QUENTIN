using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour {
    public Transform[] pieces;
    public GameObject textPuzzle;
    public GameObject puzzlePieces;
    public int first = 0;
    // Use this for initialization
    void Start () {

        first = 0;
    }
	
	// Update is called once per frame
	void Update () {
       
        
	}
    private void LateUpdate()
    {
        if (first == 0)
        {
            int j = 0;
            pieces = GameObject.Find("In").transform.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < pieces.Length; i++)
            {
                if (pieces[i].GetComponent<Puzzle_Rotate>() != null)
                {
                    if (pieces[i].GetComponent<Puzzle_Rotate>().done)
                    {
                        j++;
                    }
                }
            }
            if (j == pieces.Length - 1)
            {
                GameObject.Find("In").transform.parent.gameObject.SetActive(false);
                first++;
            }
        }

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

        if (count == pieces.Length - 1 && Player_Interaction.inPuzzle)
        {
            Player_Interaction.puzzDone = true;
        }
    }
}
