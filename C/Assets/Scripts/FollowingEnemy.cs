using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : EnemyInk
{
    public bool pauses = false;
    public int radius = 5;
    public int layer = 8;
    public void Start()
    {
        this.gameObject.layer = layer;
    }
    public void Update()
    {
        float dist = Time.deltaTime*movementSpeed*2;
        GameObject player = player = GameObject.FindGameObjectWithTag("Player");
        float px = player.transform.position.x;
        float py = player.transform.position.y;
        float dy = py - transform.position.y;
        float dx = px - transform.position.x;
        float total = (float)System.Math.Sqrt(dy * dy + dx * dx);
        //todo: check if player in the layer
        if (total < radius && this.gameObject.layer == 0 &&
            (!pauses || (((PlayerMovement)player.GetComponent("PlayerMovement")).getCurrentDirection()==(dx>=0))))
        {
            dy = dy *dist / total;
            dx = dx * dist / total;
            transform.position = new Vector3(transform.position.x + dx, transform.position.y + dy, 0);
        }
    }
}
