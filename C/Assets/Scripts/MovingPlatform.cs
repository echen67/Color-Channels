using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public int speed = 1;
    public Vector2 endPos;
    public Vector2 startPos;
    public Vector2 endDirection;
    public Vector2 startDirection;
    public int quad;    //1,2,3,4
    public bool leg = true;

    void Start()
    {
        endPos = gameObject.transform.GetChild(1).position;
        startPos = gameObject.transform.position;
        endDirection = gameObject.transform.GetChild(1).localPosition.normalized;
        startDirection = new Vector2(-endDirection.x, -endDirection.y);
        if (endDirection.x > 0 && endDirection.y > 0)
        {
            quad = 1;
        } else if (endDirection.x < 0 && endDirection.y > 0)
        {
            quad = 2;
        } else if (endDirection.x < 0 && endDirection.y < 0)
        {
            quad = 3;
        } else if (endDirection.x > 0 && endDirection.y < 0)
        {
            quad = 4;
        }
    }

    void Update()
    {
        if (leg)
        {
            transform.Translate(endDirection * Time.deltaTime * speed, Space.World);
        } else
        {
            transform.Translate(startDirection * Time.deltaTime * speed, Space.World);
        }

        if (quad == 1)
        {
            if (gameObject.transform.position.x > endPos.x && gameObject.transform.position.y > endPos.y)
            {
                leg = false;
            } else if (gameObject.transform.position.x < startPos.x && gameObject.transform.position.y < startPos.y)
            {
                leg = true;
            }
        } else if (quad == 2)
        {
            if (gameObject.transform.position.x < endPos.x && gameObject.transform.position.y > endPos.y)
            {
                leg = false;
            }
            else if (gameObject.transform.position.x > startPos.x && gameObject.transform.position.y < startPos.y)
            {
                leg = true;
            }
        } else if (quad == 3)
        {
            if (gameObject.transform.position.x < endPos.x && gameObject.transform.position.y < endPos.y)
            {
                leg = false;
            }
            else if (gameObject.transform.position.x > startPos.x && gameObject.transform.position.y > startPos.y)
            {
                leg = true;
            }
        } else if (quad == 4)
        {
            if (gameObject.transform.position.x > endPos.x && gameObject.transform.position.y < endPos.y)
            {
                leg = false;
            }
            else if (gameObject.transform.position.x < startPos.x && gameObject.transform.position.y > startPos.y)
            {
                leg = true;
            }
        }
    }
}
