using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkCollectible : MonoBehaviour {

    public string color = "red";
    public int number = 1;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            PlayerShooting shootingScript = coll.GetComponent<PlayerShooting>();
            if(color == "red")
            {
                shootingScript.addRedInk(number);
            } else if (color == "green")
            {
                shootingScript.addGreenInk(number);
            } else if (color == "blue")
            {
                shootingScript.addBlueInk(number);
            }

            Destroy(gameObject);
        }
    }

}
