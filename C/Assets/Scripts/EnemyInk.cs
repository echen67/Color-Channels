using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInk : Enemy {

    public GameObject inkCollectible;

    public override void TakeDamage(int input)
    {
        health = health - input;

        if (health <= 0)
        {
            GameObject instance = Instantiate(inkCollectible, gameObject.transform.position, Quaternion.identity);
            instance.layer = 8;
            Destroy(gameObject);
        }
    }
}
