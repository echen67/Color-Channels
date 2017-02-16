using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public static GameObject self;

    Animator animator;

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
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        body2D = gameObject.GetComponent<Rigidbody2D>();
        jumpSound = gameObject.GetComponent<AudioSource>();
        prevPos = transform.position;
    }

    Vector2 prevPos;
    float updateTime = 0;
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        absVelX = System.Math.Abs(body2D.velocity.x);
        absVelY = System.Math.Abs(body2D.velocity.y);

        //print(body2D.velocity.y);
        animator.SetBool("falling", body2D.velocity.y > 0.01 || body2D.velocity.y < -0.01);
        if (!animator.GetBool("falling")) {
            animator.SetBool("jump", false);
            animator.SetBool("doubleJump", false);
        }

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
        //Animation Handling

        Walking();
        Jumping();

        
    }

    void Walking()
    {
        //RaycastHit2D rightHit = Physics2D.BoxCast(new Vector2(transform.position.x + (transform.localScale.x / 2) + 1.2f, transform.position.y), new Vector2(0.25f, transform.localScale.y - 0.1f), 0, Vector2.right);
        bool hurt = animator.GetBool("Hurt");
        if (Input.GetKey(KeyCode.RightArrow) && !hurt)
        {
            animator.SetBool("running", true);
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed, Space.World);
            //body2D.velocity = new Vector2(Vector2.right.x * playerSpeed, body2D.velocity.y);
            newDirection = true;
            walking = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !hurt)
        {
            animator.SetBool("running", true);
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed, Space.World);
            //body2D.velocity = new Vector2(Vector2.left.x * playerSpeed, body2D.velocity.y);
            newDirection = false;
            walking = true;
        }

        //Idling
        if (absVelY == 0 && !walking)
        {
            //animator.SetInteger("Test", 0);
            animator.SetBool("running", false);
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
                if (doubleJump == 0) {
                    animator.SetBool("jump", true);
                } else if (doubleJump == 1) {
                    animator.SetBool("doubleJump", true);
                    animator.SetBool("jump", false);
                }
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
