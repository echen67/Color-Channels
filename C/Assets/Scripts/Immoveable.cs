using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immoveable : Entity {

	public override bool InkHit(string color)
    {
        return false;
    }
}
