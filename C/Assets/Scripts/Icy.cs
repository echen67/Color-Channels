using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icy : Moveable {

    //no longer needed, code moved to general platform script

    // When player touches an icy platform.
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerMovement moveCtrl = other.gameObject.GetComponent<PlayerMovement>();
            moveCtrl.setSlide(true);
        }
    }

    // When player is no longer touching an icy platform
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerMovement moveCtrl = other.gameObject
                .GetComponent<PlayerMovement>();
            moveCtrl.setSlide(false);
        }
    }
}
