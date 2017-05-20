using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

    private SoundManager soundScript;

    //private float sfxVol = 1;

	void OnEnable () {
        soundScript = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
	}

    public float UpdateSfxVolume()
    {
        return soundScript.GetSfxVol();
    }
}
