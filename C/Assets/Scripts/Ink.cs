using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour {

    public int lifetime = 200;
    public InkColor color = InkColor.Red;

    private int timer = 0;

    void Update()
    {
        //do object pooling instead
        if(timer > lifetime)
        {
            Destroy(gameObject);
        }
        timer++;
    }

	void OnTriggerEnter2D(Collider2D coll)
    {
        Entity move = coll.gameObject.GetComponent<Entity>();
        
        //make sure collision is with an entity
        if(move != null)
        {
            bool shouldDestroy = move.InkHit(color);
            if(shouldDestroy)
            {
                Destroy(gameObject);
            }
        }
    }

    public void setInkColor(InkColor input)
    {
        color = input;
    }
}
