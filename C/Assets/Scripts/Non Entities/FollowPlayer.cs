using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    public float MinY;
    public float MaxY;
    public float MinX;
    public float MaxX;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, MinX, MaxX), Mathf.Clamp(transform.position.y, MinY, MaxY), -1);
    }

    public void setTopRight(Vector2 input)
    {
        MaxX = input.x;
        MaxY = input.y;
    }

    public void setBottomLeft(Vector2 input)
    {
        MinX = input.x;
        MinY = input.y;
    }
}
