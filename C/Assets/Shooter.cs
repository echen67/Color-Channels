using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Entity {

    public GameObject laser;

    public override bool InkHit(InkColor color)
    {
        GameObject instance = Instantiate(laser, gameObject.transform.position, Quaternion.identity);
        return true;
    }
}
