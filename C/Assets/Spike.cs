using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    public float damage;

	void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            PlayerHealth ph = coll.gameObject.GetComponent<PlayerHealth>();
            ph.TakeDamage(damage);
        }
    }
}
