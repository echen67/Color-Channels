using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefab;
    public float shootingForce = 5;

    public Text redText;
    public Text greenText;
    public Text blueText;

    //how many bottles of each ink color you have left
    private int numRed = 10;
    private int numGreen = 10;
    private int numBlue = 10;

    private string inkColor = "red";
    private PlayerMovement playerMovementScript;

    //get ref to ink indicator
    //get ref to each of the ink bottle ui elements

	void Start () {
        playerMovementScript = gameObject.GetComponent<PlayerMovement>();

        redText.text = numRed + "";
        greenText.text = numGreen + "";
        blueText.text = numBlue + "";
	}
	
	void Update () {
        ShootInk();
        ChangeInkColor();
	}

    void ShootInk()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //get rid of this crap and do object pooling
            GameObject instance = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
            Ink inkScript = instance.GetComponent<Ink>();
            inkScript.setInkColor(inkColor);
            Rigidbody2D instanceR = instance.GetComponent<Rigidbody2D>();

            //Change the color of the ink sprite to match
            SpriteRenderer inkSprite = instance.GetComponent<SpriteRenderer>();
            if (inkColor == "red")
            {
                inkSprite.sprite = Resources.Load<Sprite>("RedInk") as Sprite;
                numRed--;
            }
            else if (inkColor == "green")
            {
                inkSprite.sprite = Resources.Load<Sprite>("GreenInk") as Sprite;
                numGreen--;
            }
            else if (inkColor == "blue")
            {
                inkSprite.sprite = Resources.Load<Sprite>("BlueInk") as Sprite;
                numBlue--;
            }

            UpdateInkDisplay();

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

    void ChangeInkColor()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            inkColor = "red";
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            inkColor = "green";
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            inkColor = "blue";
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            inkColor = "alpha";
        }
    }

    void UpdateInkDisplay()
    {
        redText.text = numRed + "";
        greenText.text = numGreen + "";
        blueText.text = numBlue + "";
    }

    public void addRedInk(int input)
    {
        numRed = numRed + input;
        UpdateInkDisplay();
    }

    public void addGreenInk(int input)
    {
        numGreen = numGreen + input;
        UpdateInkDisplay();
    }

    public void addBlueInk(int input)
    {
        numBlue = numBlue + input;
        UpdateInkDisplay();
    }
}
