using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public int damage = 1;

	void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth playerHealthScript = other.gameObject.GetComponent<PlayerHealth>();
            playerHealthScript.TakeDamage(damage);
        }
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemyScript = other.gameObject.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
        }
    }
}
