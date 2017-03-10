using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Colorable {

    public GameObject inkCollectible;

    public float movementSpeed = 1f;
    public int damageModifier = 10;
    public int health = 10;

    public int timer = 0;
    public int movementPeriod = 200;
    public bool flag = true;

    private bool die = false;

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

    void Start()
    {
        base.setColor();
    }

    void Update()
    {
        Movement(flag);
        if (die)
        {
            StartCoroutine("EnemyDeath");
        }
    }

    public override bool InkHit(InkColor inkColor)
    {
        bool ans = base.InkHit(inkColor);
        base.setColor();
        //update color of particles
        Transform child = gameObject.transform.GetChild(0);
        ParticleSystem ps = child.GetComponent<ParticleSystem>();
        ParticleSystemRenderer psr = child.GetComponent<ParticleSystemRenderer>();

        return ans;
    }

    //hurt the player on contact
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

    //called by spikes
    public virtual void TakeDamage(int input)
    {
        health = health - input;

        if (health <= 0)
        {
            //die = true;
            StartCoroutine("EnemyDeath");
            //Destroy(gameObject);
        }
    }

    IEnumerator EnemyDeath()
    {
        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            Debug.Log(i);
            if (i <= 0.1f)
            {
                GameObject instance = Instantiate(inkCollectible, gameObject.transform.position, Quaternion.identity);
                instance.layer = 8;
                Destroy(gameObject);
            }
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            Color c = sr.color;
            c.a = i;
            sr.color = c;
            yield return new WaitForSeconds(.1f);
        }
    }

    //super basic, predictable left/right movement
    public virtual void Movement(bool flag)
    {
        if (timer > 0)
        {
            flag = true;
        }
        if (timer > movementPeriod)
        {
            flag = false;
        }
        if (timer > 2 * movementPeriod)
        {
            timer = 0;
        }
        timer++;
        if (flag)
        {
            transform.Translate(Vector2.right * Time.deltaTime * movementSpeed, Space.World);
        }
        else
        {
            transform.Translate(Vector2.left * Time.deltaTime * movementSpeed, Space.World);
        }
    }
}
