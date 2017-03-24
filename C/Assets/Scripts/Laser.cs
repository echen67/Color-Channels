using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Colorable {

    public InkColor laserColor = InkColor.Red;

    //CHANGE THIS SO THAT DAMAGE IS TAKEN EVERY FEW SECONDS OR SO
    public int damage = 1;
    public float period = 1;

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
