using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private int SLIDING_CONSTANT = 50;

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

    private bool sliding = false;
    private int slideVal = 0;

    private Rigidbody2D body2D;

    private AudioSource jumpSound;

    void Awake()
    {
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
        if (slideVal != 0) {
            slideVal = slide(slideVal);
        }
        Jumping();


    }

    void Walking()
    {
        //RaycastHit2D rightHit = Physics2D.BoxCast(new Vector2(transform.position.x + (transform.localScale.x / 2) + 1.2f, transform.position.y), new Vector2(0.25f, transform.localScale.y - 0.1f), 0, Vector2.right);
        bool hurt = animator.GetBool("Hurt");
        if (Input.GetKey(KeyCode.RightArrow) && !hurt)
        {
            slideVal = 0; //Resets sliding value once you start walking again
            animator.SetBool("running", true);
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed, Space.World);
            //body2D.velocity = new Vector2(Vector2.right.x * playerSpeed, body2D.velocity.y);
            newDirection = true;
            walking = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !hurt)
        {
            slideVal = 0; //Resets sliding value once you start walking again
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
            if (sliding) {
                slideVal = SLIDING_CONSTANT * -1;
            }
            walking = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (sliding) {
                slideVal = SLIDING_CONSTANT;
            }
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

    /**
     * Sets whether the player is sliding or not.
     *
     * <param name="isSliding"> Whether or not the player is sliding. </param>
     */
    public void setSlide(bool isSliding) {
        sliding = isSliding;
    }

    /**
     * Slides the player using a value that approaches zero to multiply against their
     * translation transformation.
     *
     * <param name="slideValue"> The factor by which the trnasformation is multiplied. </param>
     * <returns> The updated slide value, now closer to zero. </returns>
     */
    private int slide(int slideValue) {
        float multiplier = (float) slideValue / (SLIDING_CONSTANT * 1.1f);
        transform.Translate(Vector2.right * Time.deltaTime * playerSpeed
            * multiplier, Space.World);
        if (slideValue > 0) {
            slideValue -= 1;
        } else if (slideValue < 0) {
            slideValue += 1;
        }
        return slideValue;
    }
}
