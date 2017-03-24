using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Colorable {

    //the shooter will not change layer, only color

    public InkColor shooterColor = InkColor.Red;
    public GameObject laser;

    void Start()
    {
        setColor();
    }

    public override void setColor()
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        if (shooterColor == InkColor.Red)
        {
            // Red tint
            sr.color = new Color(0.7F, 0F, 0F);
        }
        else if (shooterColor == InkColor.Green)
        {
            // Green tint
            sr.color = new Color(0F, 0.7F, 0F);
        }
        else if (shooterColor == InkColor.Blue)
        {
            // Blue tint
            sr.color = new Color(0F, 0F, 0.7F);
        }
        else if (shooterColor == InkColor.Alpha)
        {
            // Alpha layer
            sr.color = new Color(0.9F, 0.9F, 0.9F, 0.5F);
        }
        else
        {
            // Normal Colors
            sr.color = new Color(1F, 1F, 1f);
        }
    }

    public override bool InkHit(InkColor color)
    {
        shooterColor = color;
        setColor();
        GameObject instance = Instantiate(laser, gameObject.transform.position, Quaternion.identity);
        instance.transform.SetParent(gameObject.transform, true);
        Laser laserScript = instance.transform.GetChild(0).GetComponent<Laser>();
        laserScript.laserColor = color;
        laserScript.InkHit(color);
        setColor();
        return true;
    }
}
