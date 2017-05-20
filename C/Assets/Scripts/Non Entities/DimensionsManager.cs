using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimensionsManager : SFX {

    //Things that DimensionManager is responsible for:
    //Layer collisions
    //Cam culling mask
    //Changing color of the health bar

    //public int startingChannel = 1;
    public GameObject mainCam;

    private Pause pauseScript;
    private bool isPaused;

    public int playerLayer = 8;

    private GameObject healthBar;
    private RawImage healthBarTexture;
    private AudioSource channelSound;
    private Camera cam;

    void Awake()
    {
        cam = mainCam.GetComponent<Camera>();
        channelSound = gameObject.GetComponent<AudioSource>();
        pauseScript = gameObject.GetComponent<Pause>();
        //isPaused = pauseScript.isPaused;

        healthBar = GameObject.FindGameObjectWithTag("Health");
        healthBarTexture = healthBar.GetComponent<RawImage>();
        healthBarTexture.color = new Color(0.6F, .1F, .1F);

        //start on red channel
        cam.cullingMask = 127 | (1 << 8);

        Physics2D.IgnoreLayerCollision(0, 8, false);

        //ignore collisions between default and other channels
        Physics2D.IgnoreLayerCollision(0, 9, true);
        Physics2D.IgnoreLayerCollision(0, 10, true);
        Physics2D.IgnoreLayerCollision(0, 11, true);

        //ignore collisions between different channels
        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
        Physics2D.IgnoreLayerCollision(8, 11, true);
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(9, 11, true);
        Physics2D.IgnoreLayerCollision(10, 11, true);
    }
	
	void Update () {
        isPaused = pauseScript.isPaused;

        //red = layer 8
        if (Input.GetKeyDown(KeyCode.Alpha1) && !isPaused)
        {
            cam.cullingMask = 127 | (1 << 8);

            playerLayer = 8;

            //Debug.Log("hello " + Physics2D.GetLayerCollisionMask(0));
            //Physics2D.SetLayerCollisionMask(0, 0);
            //Debug.Log("hello " + Physics2D.GetLayerCollisionMask(0));

            //temporary solution until setlayercollision works
            //ignore everything >=8 that isn't this layer
            Physics2D.IgnoreLayerCollision(0, 8, false);

            Physics2D.IgnoreLayerCollision(0, 9, true);
            Physics2D.IgnoreLayerCollision(0, 10, true);
            Physics2D.IgnoreLayerCollision(0, 11, true);

            healthBarTexture.color = new Color(0.6F, .1F, .1F);

            channelSound.volume = UpdateSfxVolume();
            channelSound.Play();
        }

        //green = layer 9
        if (Input.GetKeyDown(KeyCode.Alpha2) && !isPaused)
        {
            cam.cullingMask = 127 | (1 << 9);

            playerLayer = 9;

            Physics2D.IgnoreLayerCollision(0, 9, false);

            Physics2D.IgnoreLayerCollision(0, 8, true);
            Physics2D.IgnoreLayerCollision(0, 10, true);
            Physics2D.IgnoreLayerCollision(0, 11, true);

            healthBarTexture.color = new Color(0.1F, .6F, .1F);

            channelSound.volume = UpdateSfxVolume();
            channelSound.Play();
        }

        //blue = layer 10
        if (Input.GetKeyDown(KeyCode.Alpha3) && !isPaused)
        {
            cam.cullingMask = 127 | (1 << 10);

            playerLayer = 10;

            Physics2D.IgnoreLayerCollision(0, 10, false);

            Physics2D.IgnoreLayerCollision(0, 8, true);
            Physics2D.IgnoreLayerCollision(0, 9, true);
            Physics2D.IgnoreLayerCollision(0, 11, true);

            healthBarTexture.color = new Color(0.1F, .1F, .6F);

            channelSound.volume = UpdateSfxVolume();
            channelSound.Play();
        }

        //alpha = layer 11
        if (Input.GetKeyDown(KeyCode.Alpha4) && !isPaused)
        {
            cam.cullingMask = 127 | (1 << 11);

            playerLayer = 11;

            Physics2D.IgnoreLayerCollision(0, 11, false);

            Physics2D.IgnoreLayerCollision(0, 8, true);
            Physics2D.IgnoreLayerCollision(0, 9, true);
            Physics2D.IgnoreLayerCollision(0, 10, true);

            healthBarTexture.color = new Color(0.5F, .5F, .5F);

            channelSound.volume = UpdateSfxVolume();
            channelSound.Play();
        }
    }
}
