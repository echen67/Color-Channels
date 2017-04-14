using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour {

    private SpriteRenderer scene0;
    private SpriteRenderer scene1;
    private SpriteRenderer scene2;
    private SpriteRenderer scene3;
    private SpriteRenderer scene4;
    private SpriteRenderer scene5;

    private bool startScene1 = false;
    private bool startScene2 = false;
    private bool startScene3 = false;
    private bool startScene4 = false;
    private bool startScene5 = false;

	void Start () {
        scene0 = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        scene1 = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        scene2 = gameObject.transform.GetChild(2).GetComponent<SpriteRenderer>();
        scene3 = gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>();
        scene4 = gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>();
        scene5 = gameObject.transform.GetChild(5).GetComponent<SpriteRenderer>();

        StartCoroutine("Scene0", scene0);
	}
	
    void Update()
    {
        if (startScene1)
        {
            StartCoroutine("Scene1", scene1);
            startScene1 = false;
        }

        if (startScene2)
        {
            StartCoroutine("Scene2", scene2);
            startScene2 = false;
        }

        if (startScene3)
        {
            StartCoroutine("Scene3", scene3);
            startScene3 = false;
        }

        if (startScene4)
        {
            StartCoroutine("Scene4", scene4);
            startScene4 = false;
        }

        if (startScene5)
        {
            StartCoroutine("Scene5", scene5);
            startScene5 = false;
        }
    }

	IEnumerator Scene0(SpriteRenderer sr)
    {
        for (float i = 0f; i <= 1f; i += .1f)
        {
            if (i >= 0.9f)
            {
                i = 1f;
                startScene1 = true;
            }
            Color color = sr.color;
            color.a = i;
            sr.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Scene1(SpriteRenderer sr)
    {
        yield return new WaitForSeconds(3f);
        Color c = scene0.color;
        c.a = 0;
        scene0.color = c;
        for (float i = 0f; i <= 1f; i += .1f)
        {
            if (i >= 0.9f)
            {
                i = 1f;
                startScene2 = true;
            }
            Color color = sr.color;
            color.a = i;
            sr.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Scene2(SpriteRenderer sr)
    {
        yield return new WaitForSeconds(3f);
        Color c = scene1.color;
        c.a = 0;
        scene1.color = c;
        for (float i = 0f; i <= 1f; i += .1f)
        {
            if (i >= 0.9f)
            {
                i = 1f;
                startScene3 = true;
            }
            Color color = sr.color;
            color.a = i;
            sr.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Scene3(SpriteRenderer sr)
    {
        yield return new WaitForSeconds(3f);
        Color c = scene2.color;
        c.a = 0;
        scene2.color = c;
        for (float i = 0f; i <= 1f; i += .1f)
        {
            if (i >= 0.9f)
            {
                i = 1f;
                startScene4 = true;
            }
            Color color = sr.color;
            color.a = i;
            sr.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Scene4(SpriteRenderer sr)
    {
        yield return new WaitForSeconds(3f);
        Color c = scene3.color;
        c.a = 0;
        scene3.color = c;
        for (float i = 0f; i <= 1f; i += .1f)
        {
            if (i >= 0.9f)
            {
                i = 1f;
                startScene5 = true;
            }
            Color color = sr.color;
            color.a = i;
            sr.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Scene5(SpriteRenderer sr)
    {
        yield return new WaitForSeconds(3f);
        Color c = scene4.color;
        c.a = 0;
        scene4.color = c;
        for (float i = 0f; i <= 1f; i += .1f)
        {
            if (i >= 0.9f)
            {
                i = 1f;
            }
            Color color = sr.color;
            color.a = i;
            sr.color = color;
            yield return new WaitForSeconds(.1f);
        }
    }
}
