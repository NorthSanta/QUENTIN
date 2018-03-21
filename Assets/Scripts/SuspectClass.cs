using System.Collections;
using System.Collections.Generic;
using UnityEngine.PostProcessing;
using UnityEngine;
using UnityEngine.UI;

public class SuspectClass : MonoBehaviour
{
    public GameObject buttons;
    public GameObject indict;
    public PostProcessingProfile ppProfile;
    public List<GameObject> clues = new List<GameObject>();
    [SerializeField]
    bool innocent;
    public GameObject fader;
    private float opacity;
    Color c;
    private void Start()
    {
        opacity = 1.0f;
        c = new Color(0, 0, 0, 255);
    }
    public bool inculp()
    {
        
        
        fader.GetComponent<Image>().color = c;
        c = new Color(c.r, c.g, c.b, opacity);
        opacity -= 0.4f * Time.deltaTime;
        if (opacity <= 0.0f)
        {
            
            fader.SetActive(false);
        }
       
        if (innocent)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            return false;
        }
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
       /* GameObject vell;
        GameObject nou;
        ppProfile.depthOfField.enabled = true;
        ppProfile.vignette.enabled = true;

        vell = gameObject;
        vell.SetActive(false);
        nou = (GameObject)Instantiate(gameObject);
        // GameObject copy = (GameObject)Instantiate(interact.collider.gameObject);
        nou.SetActive(true);
        nou.layer = 4;

        nou.GetComponent<BoxCollider>().enabled = false;
        // copy.GetComponent<BoxCollider>().enabled = false;

        nou.transform.parent = buttons.transform.parent;
        nou.transform.SetAsFirstSibling();
        nou.transform.localPosition = new Vector3(0, 0, 10);
        nou.transform.localRotation = Quaternion.Euler(0, 0, 0);
        nou.transform.localScale = new Vector3(1250, 2500, 100);
        indict.SetActive(true);*/
        inculp();
    }
}
