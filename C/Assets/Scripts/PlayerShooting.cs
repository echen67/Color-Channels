using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

    //Things PlayerShooting is responsible for:
    //Keeping the number of ink you  have left
    //Setting the ink indicator to the correct position

    public GameObject inkIndicator;
    public GameObject redBottle;
    public GameObject greenBottle;
    public GameObject blueBottle;
    public GameObject alphaBottle;

    public GameObject bulletPrefabRed;
    public GameObject bulletPrefabGreen;
    public GameObject bulletPrefabBlue;
    public GameObject bulletPrefabAlpha;
    public float shootingForce = 5;

    public Text redText;
    public Text greenText;
    public Text blueText;
    public Text alphaText;

    private Ink inkScript;

    //how many bottles of each ink color you have left
    private int numRed = 10;
    private int numGreen = 10;
    private int numBlue = 10;
    private int numAlpha = 10;

    public InkColor inkColor = InkColor.Red;
    private PlayerMovement playerMovementScript;

    //get ref to ink indicator
	void Start () {
        playerMovementScript = gameObject.GetComponent<PlayerMovement>();

        inkIndicator.transform.SetParent(redBottle.transform, false);
        inkIndicator.transform.SetAsFirstSibling();

        redText.text = numRed + "";
        greenText.text = numGreen + "";
        blueText.text = numBlue + "";
        alphaText.text = numAlpha + "";
	}
	
	void Update () {
        ChangeInkColor();
        ShootInk();
	}

    void ShootInk()
    {
        //FIX THIS SO THAT YOU ONLY NEED ONE BULLET PREFAB?
        //ChangeInkColor();
        if (Input.GetKeyDown(KeyCode.A))
        {
            //instantiate ink according to player color
            GameObject inkPrefab = null;
            switch(inkColor)
            {
                case InkColor.Red:
                    inkPrefab = bulletPrefabRed;
                    numRed--;
                    break;
                case InkColor.Green:
                    inkPrefab = bulletPrefabGreen;
                    numGreen--;
                    break;
                case InkColor.Blue:
                    inkPrefab = bulletPrefabBlue;
                    numBlue--;
                    break;
                case InkColor.Alpha:
                    inkPrefab = bulletPrefabAlpha;
                    numAlpha--;
                    break;
            }
            GameObject instance = Instantiate(inkPrefab, gameObject.transform.position, Quaternion.identity);

            //GameObject instance = Instantiate(bulletPrefabRed, gameObject.transform.position, Quaternion.identity);
            //inkScript = bulletPrefabRed.GetComponent<Ink>();
            //inkScript.setInkColor(inkColor);

            UpdateInkDisplay();

            //decide which way to fire ink based on player's current direction
            //eventually we will replace this with shooting based on mouse clicks?
            Rigidbody2D instanceR = instance.GetComponent<Rigidbody2D>();
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
            inkColor = InkColor.Red;
            inkIndicator.transform.SetParent(redBottle.transform, false);
            inkIndicator.transform.SetAsFirstSibling();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            inkColor = InkColor.Green;
            inkIndicator.transform.SetParent(greenBottle.transform, false);
            inkIndicator.transform.SetAsFirstSibling();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            inkColor = InkColor.Blue;
            inkIndicator.transform.SetParent(blueBottle.transform, false);
            inkIndicator.transform.SetAsFirstSibling();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            inkColor = InkColor.Alpha;
            inkIndicator.transform.SetParent(alphaBottle.transform, false);
            inkIndicator.transform.SetAsFirstSibling();
        }
    }

    void UpdateInkDisplay()
    {
        redText.text = numRed + "";
        greenText.text = numGreen + "";
        blueText.text = numBlue + "";
        alphaText.text = numAlpha + "";
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

    public void addAlphaInk(int input)
    {
        numAlpha = numAlpha + input;
        UpdateInkDisplay();
    }
}
