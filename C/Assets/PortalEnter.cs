using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnter : MonoBehaviour {

    public GameObject portalExit;
    
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            coll.transform.position = portalExit.transform.position;
        }
    }
}
