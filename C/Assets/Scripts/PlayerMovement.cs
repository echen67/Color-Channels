using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : SFX {

    // <summary>
    //    Affects how quickly the player slides on icy platforms. The higher
    //    the constant, the longer the slide.
    // </summary>
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
    private bool lastStanding = false;

    private DimensionsManager dimensionsScript;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        body2D = gameObject.GetComponent<Rigidbody2D>();
        jumpSound = gameObject.GetComponent<AudioSource>();
        prevPos = transform.position;

        dimensionsScript = GameObject.FindGameObjectWithTag("Dimensions").GetComponent<DimensionsManager>();
    }

    Vector2 prevPos;
    float updateTime = 0;
	void Update () {

        //Vector3 end = new Vector3(transform.position.x, transform.position.y - 1, 0);
        //Debug.DrawLine(transform.position, end, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null && (hit.collider.tag == "Platform" || hit.collider.tag == "Moving") 
            && (hit.collider.gameObject.layer == dimensionsScript.playerLayer || hit.collider.gameObject.layer == 0))
        {
            standing = true;
            if (hit.collider.tag == "Moving")
            {
                Debug.Log("moving platform");
                gameObject.transform.SetParent(hit.transform);
            } else
            {
                gameObject.transform.SetParent(null);
                Debug.Log("unparent");
            }
        } else
        {
            standing = false;
            gameObject.transform.SetParent(null);
        }

        absVelX = System.Math.Abs(body2D.velocity.x);
        absVelY = System.Math.Abs(body2D.velocity.y);

        animator.SetBool("falling", body2D.velocity.y > 0.01 || body2D.velocity.y < -0.01);
        if (!animator.GetBool("falling")) {
            animator.SetBool("jump", false);
            animator.SetBool("doubleJump", false);
        }

        lastStanding = standing;
        //standing = absVelY <= standingThreshold;
        if (standing && lastStanding)
        {
            doubleJump = 0;
        }

        //The following is an incomplete fix for the infinite-jumping-under-platforms. There are two problems with it:
        //First, I don't think groundLayer is correct; it should correspond to the player's layer. Fixing this should(?) fix the collision detection.
        //Second, right now only the white platform (the one not listed under the "Platforms" category) is considered a platform. Either add the platform script to the other platforms (like what white currently has) or tag each individual platform with the "Platform" tag and replace FindObjectsOfType(typeof(Platform)) with FindGameObjectsWithTag("Platform").
        //- Jacob

        //Platform[] platforms = GameObject.FindObjectsOfType(typeof(Platform)) as Platform[];
        //print(platforms.Length);
        //foreach (Platform p in platforms)
        //{
        //    print(p);
        //    if (Physics2D.OverlapCircle(p.transform.position, 0.15f, groundLayer))
        //    {
        //        print("hit");
        //        standing = true;
        //        doubleJump = 0;
        //        break;
        //    }
        //}

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
                jumpSound.volume = UpdateSfxVolume();
                jumpSound.Play();
            }
        }
    }

    public bool getCurrentDirection()
    {
        return currentDirection;
    }

    /**
     <summary>
       Sets whether the player is sliding or not.
     </summary>
     <param name="isSliding"> Whether or not the player is sliding. </param>
     */
    public void setSlide(bool isSliding) {
        sliding = isSliding;
    }

    /**
     <summary>
       Slides the player using a value that approaches zero to multiply against their
       translation transformation.
     </summary>
     <param name="slideValue"> The factor by which the trnasformation is multiplied. </param>
     <returns> The updated slide value, now closer to zero. </returns>
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
