using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : EnemyInk
{
    public DimensionsManager dimensions;
    public bool pauses = false;
    public int radius = 5;
    public int layer = 8;

    public void Start()
    {
        this.gameObject.layer = layer;
        dimensions = GameObject.FindGameObjectWithTag("Dimensions").GetComponent<DimensionsManager>();
    }
    public void Update()
    {
        float dist = Time.deltaTime * movementSpeed * 2;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float px = player.transform.position.x;
        float py = player.transform.position.y;
        float dy = py - transform.position.y;
        float dx = px - transform.position.x;
        float total = (float)System.Math.Sqrt(dy * dy + dx * dx);

        InkColor color = player.GetComponent<PlayerShooting>().inkColor;
        int layer = InkColor.Red == color ? 8 : InkColor.Green == color ? 9 : InkColor.Blue == color ? 10 : 11;
        if (total < radius && this.gameObject.layer == dimensions.playerLayer &&
            (!pauses || (((PlayerMovement)player.GetComponent("PlayerMovement")).getCurrentDirection()==(dx>=0))))
        {
            dy = dy *dist / total;
            dx = dx * dist / total;
            transform.position = new Vector3(transform.position.x + dx, transform.position.y + dy, 0);
        }
    }
}
