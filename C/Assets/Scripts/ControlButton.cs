using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : SFX {

    public GameObject controlPanel;

    public void ControlClicked()
    {
        controlPanel.SetActive(true);
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.volume = UpdateSfxVolume();
        audio.Play();
    }
}
