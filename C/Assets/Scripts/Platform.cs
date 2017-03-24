using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : Colorable {

    public InkColor inkColor = InkColor.Red;

    public AudioSource timerSound;
    private bool start1 = false;
    private bool start2 = false;
    private float timeLeft = 3.0f;

    private GameObject outline;
    private SpriteRenderer outlineSR;

    private SpriteRenderer sr;

	void Awake () {
        sr = gameObject.GetComponent<SpriteRenderer>();
        timerSound = gameObject.GetComponent<AudioSource>();
        outline = gameObject.transform.GetChild(0).gameObject;
        outlineSR = outline.gameObject.GetComponent<SpriteRenderer>();

        InkHit(inkColor);
        setColor();
        setOutlineColor(inkColor);
	}

    void Update()
    {
        if (start1 && inkColor == InkColor.Alpha)
        {
            timeLeft -= Time.deltaTime;
            if (!start2)
            {
                InvokeRepeating("countdown", 0.0f, 1.0f);
                start2 = true;
            }
        }
    }

    //for timed platforms
    void countdown()
    {
        if (timeLeft > 0)
        {
            timerSound.Play();
        }
        else
        {
            Destroy(gameObject);
            start1 = false;
            CancelInvoke();
        }
    }

    public override bool InkHit(InkColor inkColor)
    {
        base.InkHit(inkColor);
        this.inkColor = inkColor;
        setColor();
        setOutlineColor(inkColor);
        return base.InkHit(inkColor);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //If platform is red, it is bouncy
        if (other.gameObject.tag == "Player" && inkColor == InkColor.Red)
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }

        //for icy platforms
        if (other.gameObject.tag == "Player" && inkColor == InkColor.Blue)
        {
            PlayerMovement moveCtrl = other.gameObject.GetComponent<PlayerMovement>();
            moveCtrl.setSlide(true);
        }

        //for timed platforms
        if (inkColor == InkColor.Alpha)
        {
            start1 = true;
        }
    }

    //for icy platforms
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && inkColor == InkColor.Blue)
        {
            PlayerMovement moveCtrl = other.gameObject
                .GetComponent<PlayerMovement>();
            moveCtrl.setSlide(false);
        }
    }

    public void setOutlineColor(InkColor input)
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
