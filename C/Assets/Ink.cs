using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour {

    public int lifetime = 200;

    private int timer = 0;

    void Update()
    {
        if(timer > lifetime)
        {
            Destroy(gameObject);
        }
        timer++;
    }

	void OnCollisionEnter2D(Collision2D coll)
    {
        //
    }
}
