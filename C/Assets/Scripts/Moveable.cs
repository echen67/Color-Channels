using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : Entity {

	public override bool InkHit(string inkColor)
    {
        Debug.Log("InkHit called");
        //each type of entity will override this
        //for example, platforms, spikes, and enemies will actually change channels, while doors and black platforms won't
        if (inkColor == "red")
        {
            gameObject.layer = 8;
        }

        if (inkColor == "green")
        {
            gameObject.layer = 9;
        }

        if (inkColor == "blue")
        {
            gameObject.layer = 10;
        }

        if (inkColor == "alpha")
        {
            gameObject.layer = 11;
        }

        return true;
    }
}
