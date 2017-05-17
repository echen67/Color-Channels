using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : SFX {

    public GameObject creditsPanel;

    public void CreditsClicked()
    {
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.volume = UpdateSfxVolume();
        audio.Play();
        creditsPanel.SetActive(true);
    }
}
