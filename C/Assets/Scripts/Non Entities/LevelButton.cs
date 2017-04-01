using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int sceneNum = 1;

    void OnMouseEnter()
    {
        gameObject.transform.localScale += new Vector3(0.1f, 0, 0);
    }

    void OnMouseExit()
    {
        gameObject.transform.localScale -= new Vector3(0.1f, 0, 0);
    }

    void OnMouseDown()
    {
        SceneManager.LoadScene(sceneNum);
    }

    /*public void PlayClicked()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
        SceneManager.LoadScene(1);
    }*/
}
