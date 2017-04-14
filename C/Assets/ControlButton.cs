using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlButton : MonoBehaviour {

    public GameObject controlPanel;

    public void ControlClicked()
    {
        controlPanel.SetActive(true);
        AudioSource audio = gameObject.GetComponent<AudioSource>();
        audio.Play();
    }
}
