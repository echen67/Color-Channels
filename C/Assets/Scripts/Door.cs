using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Entity {

    public bool unlock = false;

    [Header("The number of times the door needs to be hit to be unlocked")]
    public int numToUnlock = 1;     //the number of times the door needs to be hit to be unlocked

    [Header("Enter the scene number of the scene you want to travel to")]
    public int SceneNum = 0;

    public override bool InkHit(InkColor color)
    {
        numToUnlock -= 1;
        if (numToUnlock <= 0)
        {
            unlock = true;
            GameObject locked = gameObject.transform.GetChild(0).gameObject;
            Destroy(locked);
        }
        return true;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
            if(coll.gameObject.tag == "Player" && unlock)
            {
                SceneManager.LoadScene(SceneNum);
            }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && unlock)
        {
            SceneManager.LoadScene(SceneNum);
        }
    }
}
