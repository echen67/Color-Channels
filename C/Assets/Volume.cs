using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

    public static GameObject self;

    private float musicVol = 1;
    private float sfxVol = 1;

    private Slider musicSlider;
    private Slider sfxSlider;

    private SoundManager soundScript;

	void Awake () {
        soundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();

        musicSlider = gameObject.transform.GetChild(1).gameObject.GetComponent<Slider>();
        sfxSlider = gameObject.transform.GetChild(3).gameObject.GetComponent<Slider>();

        musicSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
	}

    //Return slider values to what they were before scene reload
    void OnEnable()
    {
        Debug.Log("Enable");
        musicSlider.value = soundScript.GetMusicVol();
        sfxSlider.value = soundScript.GetSfxVol();
        //sfxSlider.value = 0;
    }

    //Update actual volume using slider values
    void UpdateVolume ()
    {
        Debug.Log("Update");
        soundScript.UpdateVolume(musicSlider.value, sfxSlider.value);
    }
}
