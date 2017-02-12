using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkCollectible : MonoBehaviour {

    public string color;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {

        }
    }

}
