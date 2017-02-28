using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkCollectible : MonoBehaviour {

    public InkColor color = InkColor.Red;
    public int number = 1;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            PlayerShooting shootingScript = coll.GetComponent<PlayerShooting>();
            switch(color)
            {
                case InkColor.Red:
                    shootingScript.addRedInk(number);
                    break;
                case InkColor.Green:
                    shootingScript.addGreenInk(number);
                    break;
                case InkColor.Blue:
                    shootingScript.addBlueInk(number);
                    break;
            }

            Destroy(gameObject);
        }
    }

}
