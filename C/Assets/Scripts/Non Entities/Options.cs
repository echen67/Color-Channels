using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    public GameObject optionsPanel;
    public GameObject canvas;

    private bool isOptionsOpen = false;

    //temp
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isOptionsOpen)
        {
            GameObject instance = Instantiate(optionsPanel);
            instance.transform.SetParent(canvas.transform, false);
            isOptionsOpen = true;
        }
    }*/

    /*void OnMouseEnter()
    {
        gameObject.transform.localScale += new Vector3(5f, 0, 0);
    }

    void OnMouseExit()
    {
        gameObject.transform.localScale -= new Vector3(5f, 0, 0);
    }

    void OnMouseDown()
    {
        GameObject instance = Instantiate(optionsPanel);
        instance.transform.SetParent(canvas.transform, false);
        isOptionsOpen = true;
    }*/

    public void OptionsClicked()
    {
        optionsPanel.SetActive(true);
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
    }
}
