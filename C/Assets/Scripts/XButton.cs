using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour {

    GameObject parent;

    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }

	void OnMouseDown()
    {
        Destroy(parent);
    }

    void OnMouseEnter()
    {
        gameObject.transform.localScale += new Vector3(5f, 0, 0);
    }

    void OnMouseExit()
    {
        gameObject.transform.localScale -= new Vector3(5f, 0, 0);
    }

    public void CloseWindow()
    {
        GameObject parent = gameObject.transform.parent.gameObject;
        parent.SetActive(false);
    }
}
