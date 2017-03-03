using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : Entity {

	public override bool InkHit(InkColor inkColor)
    {
        //each type of entity will override this
        //for example, platforms, spikes, and enemies will actually change channels, while doors and black platforms won't
        switch(inkColor)
        {
            case InkColor.Red:
                gameObject.layer = 8;
                break;
            case InkColor.Green:
                gameObject.layer = 9;
                break;
            case InkColor.Blue:
                gameObject.layer = 10;
                break;
            case InkColor.Alpha:
                gameObject.layer = 11;
                break;
        }

        return true;
    }
}
