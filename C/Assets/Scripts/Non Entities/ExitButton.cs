using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour {

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
        Application.Quit();
    }*/

    public void ExitClicked()
    {
        Application.Quit();
    }
}
