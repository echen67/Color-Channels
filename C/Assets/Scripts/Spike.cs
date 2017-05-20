using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Colorable {

    public InkColor spikeColor = InkColor.Red;
    public int damage;
    private int health = 10;
    GameObject player;

    SpriteRenderer outlineSR;

    void Start() {
        outlineSR = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        setOutlineColor(spikeColor);

        player = GameObject.FindGameObjectWithTag("Player");
        InkHit(spikeColor);
        setColor();
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        setColor(); //
    }

	void OnCollisionEnter2D(Collision2D coll)
    {
           //push player back, hurt them
        if(coll.gameObject.tag == "Player")
        {
            PlayerHealth ph = coll.gameObject.GetComponent<PlayerHealth>();
            Rigidbody2D rig = player.GetComponent<Rigidbody2D>();
            rig.velocity = new Vector2(-Mathf.Sign(player.transform.rotation.y) * 12, -rig.velocity.y/1);
            coll.gameObject.GetComponent<Animator>().SetBool("Hurt", true);
            ph.TakeDamage(damage);
        }
        //Spikes hurt enemies, but enemies also hurt spikes 
        if (coll.gameObject.tag == "Enemy")
        {
            Enemy enemyScript = coll.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
            int takeDamage = enemyScript.getDamageModifier();
            health = health - takeDamage;
        }
    }

    public override bool InkHit(InkColor inkColor)
    {
        base.InkHit(inkColor);
        this.spikeColor = inkColor;
        setColor();
        setOutlineColor(inkColor);
        return base.InkHit(inkColor);
    }

    void setOutlineColor(InkColor input)
    {
        switch (input)
        {
            case InkColor.Red:
                outlineSR.color = new Color(0.7F, 0F, 0F, 0.5F);
                break;
            case InkColor.Green:
                outlineSR.color = new Color(0F, 0.7F, 0F, 0.5F);
                break;
            case InkColor.Blue:
                outlineSR.color = new Color(0F, 0F, 0.7F, 0.5F);
                break;
            case InkColor.Alpha:
                outlineSR.color = new Color(0.9F, 0.9F, 0.9F, 0.5F);
                break;
        }
    }
}
