using UnityEngine;
using System.Collections;

public class Scannable : MonoBehaviour {
    //public Animator UIAnim;
    //S'han de posar els escanejables dins de un EmptyObject per separat cadascun
    public Transform[] active;

    public void Ping() {
        //UIAnim.SetTrigger("Ping");
        active = transform.GetComponentsInChildren<Transform>(true);

        active[1].gameObject.SetActive(true);
    }
}
