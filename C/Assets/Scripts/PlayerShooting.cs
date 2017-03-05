using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

    public GameObject bulletPrefabRed;
    public GameObject bulletPrefabGreen;
    public GameObject bulletPrefabBlue;
    public float shootingForce = 5;

    public Text redText;
    public Text greenText;
    public Text blueText;

    private Ink inkScript;

    //how many bottles of each ink color you have left
    private int numRed = 10;
    private int numGreen = 10;
    private int numBlue = 10;

    public InkColor inkColor = InkColor.Red;
    private PlayerMovement playerMovementScript;

    //get ref to ink indicator
	void Start () {
        playerMovementScript = gameObject.GetComponent<PlayerMovement>();
        //inkScript = bulletPrefabRed.GetComponent<Ink>();

        redText.text = numRed + "";
        greenText.text = numGreen + "";
        blueText.text = numBlue + "";
	}
	
	void Update () {
        ChangeInkColor();
        ShootInk();
	}

    void ShootInk()
    {
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
            }
            GameObject instance = Instantiate(inkPrefab, gameObject.transform.position, Quaternion.identity);

            //GameObject instance = Instantiate(bulletPrefabRed, gameObject.transform.position, Quaternion.identity);
            //inkScript = bulletPrefabRed.GetComponent<Ink>();
            //inkScript.setInkColor(inkColor);

            UpdateInkDisplay();

            //FIX THIS SO THAT YOU ONLY NEED ONE BULLET PREFAB
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
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            inkColor = InkColor.Green;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            inkColor = InkColor.Blue;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            inkColor = InkColor.Alpha;
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
