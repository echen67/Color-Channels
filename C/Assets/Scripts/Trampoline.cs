using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour {

    public float force = 20;

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody2D r = other.gameObject.GetComponent<Rigidbody2D>();
            r.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }
}
