using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public static GameObject self;
    private AudioSource audioSrc;

    public float music = 1;
    public float sfx = 1;

	void Awake () {
        if (self == null)
        {
            DontDestroyOnLoad(gameObject);
            self = gameObject;
        }
        else if (self != this)
        {
            Destroy(gameObject);
        }

        audioSrc = gameObject.GetComponent<AudioSource>();
    }
	
    public float GetSfxVol()
    {
        return sfx;
    }

    public float GetMusicVol()
    {
        return music;
    }

    //Used by Volume to update actual volumes using slider values
	public void UpdateVolume(float musicVol, float sfxVol)
    {
        music = musicVol;
        sfx = sfxVol;

        audioSrc.volume = musicVol;
    }
}
