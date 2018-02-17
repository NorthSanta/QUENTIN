using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectClass : MonoBehaviour
{
    [SerializeField]
    GameObject[] clues;
    public bool inculp()
    {

        int total = 0;
        for (int i = 0; i < Player_Interaction.foundClues.Count; i++)
        {
            for (int j = 0; j < clues.Length; j++)
            {
                if (Player_Interaction.foundClues[i].GetComponent<Clue_Index>().clueIndex == clues[j].GetComponent<Clue_Index>().clueIndex)
                {
                    total++;
                }
            }


        }
        if (total >= 2)
        {
            return true;
        }
        return false;
    }
}
