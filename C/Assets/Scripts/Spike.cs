using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Colorable {

    public int damage;
    private int health = 10;
    GameObject player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        setColor();
    }

	void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            PlayerHealth ph = coll.gameObject.GetComponent<PlayerHealth>();
            Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
            rig.velocity = new Vector2(-Mathf.Sign(player.transform.rotation.y) * 12, -rig.velocity.y/1);
            coll.gameObject.GetComponent<Animator>().SetBool("Hurt", true);
            ph.TakeDamage(damage);
        }
        if (coll.gameObject.tag == "Enemy")
        {
            Enemy enemyScript = coll.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
            int takeDamage = enemyScript.getDamageModifier();
            health = health - takeDamage;
        }
    }
}
