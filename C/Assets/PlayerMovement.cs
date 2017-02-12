using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public static GameObject self;

    public float playerSpeed;
    public float jumpheight;

    private float absVelX = 0f;
    private float absVelY = 0f;
    private bool standing;
    private float standingThreshold;

    private bool currentDirection = false;  //left is false, right is true
    private bool newDirection = false;
    private bool walking = false;
    private bool jumping = false;
    private int doubleJump = 0;

    private Rigidbody2D body2D;

    private AudioSource jumpSound;
	
    void Awake()
    {
        if (self == null)
        {
            DontDestroyOnLoad(gameObject);
            self = gameObject;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        body2D = gameObject.GetComponent<Rigidbody2D>();
        jumpSound = gameObject.GetComponent<AudioSource>();
    }

	void Update () {
        absVelX = System.Math.Abs(body2D.velocity.x);
        absVelY = System.Math.Abs(body2D.velocity.y);

        standing = absVelY <= standingThreshold;
        if (standing)
        {
            doubleJump = 0;
        }

        if (currentDirection != newDirection)
        {
            transform.Rotate(new Vector3(0, -180, 0));
            currentDirection = newDirection;
        }

        Walking();
        Jumping();
    }

    void Walking()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed, Space.World);
            newDirection = true;
            walking = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed, Space.World);
            newDirection = false;
            walking = true;
        }

        //Idling
        if (absVelY == 0 && !walking)
        {
            //animator.SetInteger("Test", 0);
        }

        //Stop walking left and right
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            walking = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            walking = false;
        }
    }

    void Jumping()
    {

        if (standing == true || doubleJump < 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                body2D.velocity = Vector2.up * jumpheight;
                jumping = true;
                doubleJump++;
                body2D.gravityScale = 3f;
                jumpSound.Play();
            }
        }
    }

    public bool getCurrentDirection()
    {
        return currentDirection;
    }
}
