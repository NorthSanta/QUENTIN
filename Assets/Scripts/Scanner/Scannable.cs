using UnityEngine;
using System.Collections;

public class Scannable : MonoBehaviour {
    //public Animator UIAnim;
    //S'han de posar els escanejables dins de un EmptyObject per separat cadascun
    //public Transform[] active;

    private float opacity;

    private Color c;

    private bool pinged;

    private float timer;

    private Collider col;

    public void Start() {
        opacity = 0.0f;
        c = new Color(255, 255, 255, 0);
        pinged = false;
        timer = 0.0f;
        col = GetComponent<BoxCollider>();
    }

    public void Update() {
        gameObject.GetComponent<SpriteRenderer>().color = c;
        if (pinged) {
            c = new Color(c.r, c.g, c.b, opacity);
            timer += Time.deltaTime;
            if (timer <= 2.0f) {
                opacity += 0.3f * Time.deltaTime;
                if (opacity > 0.95f) {
                    opacity = 1.0f;
                }
            }
            else{
                opacity -= 0.3f * Time.deltaTime;
                if (opacity <= 0.0f) {
                    opacity = 0.0f;
                    if (col != null)
                    {
                        col.enabled = false;
                    }
                    pinged = false;
                    timer = 0.0f;
                }
            }
        }
    }

    public void Ping() {
        //UIAnim.SetTrigger("Ping");
        //active = transform.GetComponentsInChildren<Transform>(true);
        //active[1].gameObject.SetActive(true);
        if (col != null)
        {
            col.enabled = true;
        }
        pinged = true;
        timer = 0.0f;
    }
}
