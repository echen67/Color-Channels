using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Moveable {

    private int damageModifier = 1;

    void SetDamageModifier(int input)
    {
        damageModifier = input;
    }

	void OnCollisionEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            PlayerHealth playerHealthScript = coll.GetComponent<PlayerHealth>();
            playerHealthScript.TakeDamage(damageModifier);
        }
    }
}
