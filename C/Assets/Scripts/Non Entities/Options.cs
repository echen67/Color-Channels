using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour {

    public GameObject optionsPanel;
    public GameObject canvas;

    private bool isOptionsOpen = false;

    //temp, since buttons wont freaking work inside editor >:(
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !isOptionsOpen)
        {
            GameObject instance = Instantiate(optionsPanel);
            instance.transform.SetParent(canvas.transform, false);
            isOptionsOpen = true;
        }
    }

    void OnMouseEnter()
    {
        gameObject.transform.localScale += new Vector3(5f, 0, 0);
    }

    void OnMouseExit()
    {
        gameObject.transform.localScale -= new Vector3(5f, 0, 0);
    }

    /*void OnMouseDown()
    {
        //open options panel
    }*/

    public void OptionsClicked()
    {
        Debug.Log("helloooo");
        Instantiate(optionsPanel);
    }
}
