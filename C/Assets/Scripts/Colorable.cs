using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Colorable : Moveable {

    public void setColor() {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (gameObject.layer == 8) {
            // Red tint
            sr.color = new Color(0.7F, 0F, 0F);
        } else if (gameObject.layer == 9) {
            // Green tint
            sr.color = new Color(0F, 0.7F, 0F);
        } else if (gameObject.layer == 10)  {
            // Blue tint
            sr.color = new Color(0F, 0F, 0.7F);
        } else if (gameObject.layer == 11) {
            // Alpha layer
            sr.color = new Color(0.9F, 0.9F, 0.9F, 0.5F);
        } else {
            // Normal Colors
            sr.color = new Color(1F, 1F, 1f);
        }
    }
}
