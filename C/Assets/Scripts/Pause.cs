using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour {

    public bool isPaused = false;

    private Image image;

    void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
        }

        //you also have to disable: 
        //shooting
        //player turning from side to side
        //changing channels
        //changing ink color
        //also, ink drops will still disappear while paused...yikes
        if (isPaused)
        {
            Time.timeScale = 0;
            Sprite paused = Resources.Load<Sprite>("Pause") as Sprite;
            image.sprite = paused;
        } else
        {
            Time.timeScale = 1;
            Sprite play = Resources.Load<Sprite>("Play") as Sprite;
            image.sprite = play;
        }
    }

    void OnMouseDown()
    {
        isPaused = !isPaused;
    }

}
