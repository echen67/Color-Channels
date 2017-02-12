using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public float shootingForce = 5;

    private PlayerMovement playerMovementScript;

	void Start () {
        playerMovementScript = gameObject.GetComponent<PlayerMovement>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.A))
        {
            //get rid of this crap and do object pooling
            GameObject instance = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
            Rigidbody2D instanceR = instance.GetComponent<Rigidbody2D>();

            //decide which way to fire ink based on player's current direction
            //eventually we will replace this with shooting based on mouse clicks?
            bool currentDirection = playerMovementScript.getCurrentDirection();
            if (currentDirection == false)
            {
                instanceR.AddForce(Vector2.left * shootingForce, ForceMode2D.Impulse);
            }
            else
            {
                instanceR.AddForce(Vector2.right * shootingForce, ForceMode2D.Impulse);
            }
        }
	}
}
