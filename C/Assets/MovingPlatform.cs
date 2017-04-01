using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public int xSpeed = 1;
    public int ySpeed = 1;
    public int xDistance = 1;
    public int yDistance = 1;
    int timer = 0;

    void Update()
    {
        if (timer <= xDistance)
        {
            transform.Translate(Vector2.right * Time.deltaTime * xSpeed, Space.World);
        }
        timer++;
    }

    IEnumerator xTravel()
    {
        for (int i = 0; i <= xSpeed; i++)
        {
            transform.Translate(Vector2.right * Time.deltaTime * xSpeed, Space.World);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator yTravel()
    {
        for (int i = 0; i <= ySpeed; i++)
        {
            //gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + i);
            yield return new WaitForSeconds(.5f);
        }
    }
}
