using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : SFX {

    public GameObject optionsPanel;
    public GameObject canvas;

    private bool isOptionsOpen = false;

    public void OptionsClicked()
    {
        //Debug.Log(UpdateSfxVolume());
        optionsPanel.SetActive(true);
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.volume = UpdateSfxVolume();
        //Debug.Log(UpdateSfxVolume());
        audio.Play();
    }
}
