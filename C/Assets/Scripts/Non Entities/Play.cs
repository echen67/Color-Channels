using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Play : SFX {

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void PlayClicked()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.volume = UpdateSfxVolume();
        audio.Play();

        StartCoroutine("Load");
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(1);
    }
}
