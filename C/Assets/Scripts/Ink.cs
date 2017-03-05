using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ink : MonoBehaviour {

    public int lifetime = 200;
    public InkColor color = InkColor.Red;
    private SpriteRenderer sr;

    private int timer = 0;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    //Ink disappears after a certain amount of time
    void Update()
    {
        if(timer > lifetime)
        {
            Destroy(gameObject);
        }
        timer++;
    }

    //Whenever the ink hits something, it'll attempt to call InkHit() on that object
    //What happens to that object depends on its specific implementation of that method
	void OnTriggerEnter2D(Collider2D coll)
    {
        Entity move = coll.gameObject.GetComponent<Entity>();
        //make sure collision is with an entity
        //The ink will be able to pass through certain things, such as the player and black platforms
        if(move != null)
        {
            bool shouldDestroy = move.InkHit(color);
            if(shouldDestroy)
            {
                Destroy(gameObject);
            }
        }
    }

    //called by PlayerShooting script
    public void setInkColor(InkColor input)
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        color = input;
        switch (input)
        {
            case InkColor.Red:
                sr.color = new Color(0.7F, 0F, 0F);
                break;
            case InkColor.Green:
                sr.color = new Color(0F, 0.7F, 0F);
                break;
            case InkColor.Blue:
                sr.color = new Color(0F, 0F, 0.7F);
                break;
            case InkColor.Alpha:
                sr.color = new Color(0.9F, 0.9F, 0.9F, 0.5F);
                break;
        }
    }
}
