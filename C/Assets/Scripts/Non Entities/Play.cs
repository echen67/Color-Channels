using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour {

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
        SceneManager.LoadScene(1);
    }*/

    public void PlayClicked()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play();

        StartCoroutine("Load");
        //SceneManager.LoadScene(1);
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(1);
    }
}
