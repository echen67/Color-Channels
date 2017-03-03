using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timed : MonoBehaviour {

    public AudioSource timerSound;
    bool start1 = false;
    bool start2 = false;
    float timeLeft = 3.0f;

    void Start() {
        timerSound = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        start1 = true;
    }

    void Update() {
        if (start1) {
            timeLeft -= Time.deltaTime;
            if (!start2) {
                InvokeRepeating("countdown", 0.0f, 1.0f);
                start2 = true;
            }
        }
    }

    void countdown() {
        if (timeLeft > 0) {
            timerSound.Play();
        } else {
            Destroy(gameObject);
            start1 = false;
            CancelInvoke();
        }
    }

    /**void OnGUI() {
        GUI.Label(new Rect(gameObject.transform.position.x + 100, gameObject.transform.position.y + 30, 60, 20), string.Format("{0:f1}", timeLeft));
    }**/
}
