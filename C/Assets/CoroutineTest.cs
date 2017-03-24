using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour {

    private SpriteRenderer sr;

    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
	
	void Update () {
        Color c = sr.color;
		if (Input.GetKeyDown(KeyCode.F) && c.a == 1)
        {
            StartCoroutine("Fade");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartCoroutine("Appear");
        }
	}

    IEnumerator Fade()
    {
        for (float f = 1f; f >= 0f; f -= 0.1f)
        {
            //Debug.Log(f);
            //set the alpha component of the color to f
            //hacky code cuz f wouldnt go below .0999 for some reason?
            if (f <= 0.1)
            {
                f = 0;
            }
            Color c = sr.color;
            c.a = f;
            sr.color = c;
            //yield return null;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Appear()
    {
        for (float g = 0f; g <= 1f; g += 0.1f)
        {
            if (g >= 0.9f)
            {
                g = 1f;
            }
            Color c = sr.color;
            c.a = g;
            sr.color = c;
            Debug.Log(c.a);
            yield return new WaitForSeconds(.1f);
        }
    }
}
