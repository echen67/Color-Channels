using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immoveable : Entity {

	public override bool InkHit(InkColor color)
    {
        return false;
    }
}
