using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerShiftingEnemy : EnemyInk
{
    public float time = 5;
    public int initialLayer = 8;
    private float temptime = 0;

    public void Start()
    {
        this.gameObject.layer = initialLayer;
    }
    public void Update()
    {
        temptime += Time.deltaTime;
        if (temptime > time)
        {
            temptime = 0;
            this.gameObject.layer = ((this.gameObject.layer - 7) % 4) + 8;
        }
    }
}
