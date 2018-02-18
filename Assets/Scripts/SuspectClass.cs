using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuspectClass : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> clues = new List<GameObject>();
    public bool inculp()
    {

        int total = 0;

        for (int i = 0; i < clues.Count; i++)
        {

            /*for (int j = 0; j < Clue_Manager.solution.Count; j++)
            {
                if (Clue_Manager.solution[j] == clues[i].GetComponent<Clue_Index>().clueIndex)
                {
                    print(Clue_Manager.solution[j]);
                    total++;
                }
            }*/
            if (Clue_Manager.solution.Contains(clues[i].GetComponent<Clue_Index>().clueIndex))
            {
                total++;
            }

        }
        if (total%3 >= 2)
        {
           // print("Culpable!");
            transform.GetChild(0).gameObject.SetActive(true);
            return true;
        }
       // print("Inocente!");
        transform.GetChild(1).gameObject.SetActive(true);
        return false;
    }
    private void OnMouseDown()
    {
        inculp();
    }
}
