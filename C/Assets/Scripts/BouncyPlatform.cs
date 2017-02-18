using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyPlatform : Moveable {

    void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
    }
}
