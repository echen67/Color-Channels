using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Moveable {

    public int damageModifier = 10;
    public int health = 10;

    public int getDamageModifier()
    {
        return damageModifier;
    }

    public void SetDamageModifier(int input)
    {
        damageModifier = input;
    } 
    
    public void SetHealth(int input)
    {
        health = input;
    }

	public virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            GameObject player = coll.gameObject;
            PlayerHealth playerHealthScript = player.GetComponent<PlayerHealth>();
            Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
            rig.velocity = new Vector2(-Mathf.Sign(player.transform.rotation.y) * 12, -rig.velocity.y / 1);
            player.GetComponent<Animator>().SetBool("Hurt", true);
            playerHealthScript.TakeDamage(damageModifier);
        }
    }

    public virtual void TakeDamage(int input)
    {
        health = health - input;

        if (health <= 0)
        {
            //GameObject instance = Instantiate(inkCollectible, gameObject.transform.position, Quaternion.identity);
            //instance.layer = 8;
            Destroy(gameObject);
        }
    }
}
