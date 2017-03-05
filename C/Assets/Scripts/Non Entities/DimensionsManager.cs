using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionsManager : MonoBehaviour {

    public int startingChannel = 1;
    public GameObject mainCam;
    private AudioSource channelSound;
    Camera cam;

    void Awake()
    {
        cam = mainCam.GetComponent<Camera>();
        channelSound = gameObject.GetComponent<AudioSource>();

        cam.cullingMask = 127 | (1 << 8);

        Physics2D.IgnoreLayerCollision(0, 8, false);

        Physics2D.IgnoreLayerCollision(0, 9, true);
        Physics2D.IgnoreLayerCollision(0, 10, true);
        Physics2D.IgnoreLayerCollision(0, 11, true);

        Physics2D.IgnoreLayerCollision(8, 9, true);
        Physics2D.IgnoreLayerCollision(8, 10, true);
        Physics2D.IgnoreLayerCollision(8, 11, true);

        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(9, 11, true);

        Physics2D.IgnoreLayerCollision(10, 11, true);
    }

	void Start () {
        //cam = mainCam.GetComponent<Camera>();
        //channelSound = gameObject.GetComponent<AudioSource>();

        //temp
        //start on red
        cam.cullingMask = 127 | (1 << 8);
        
        Physics2D.IgnoreLayerCollision(0, 8, false);

        Physics2D.IgnoreLayerCollision(0, 9, true);
        Physics2D.IgnoreLayerCollision(0, 10, true);
        Physics2D.IgnoreLayerCollision(0, 11, true);
    }
	
	void Update () {
        //red = layer 8
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam.cullingMask = 127 | (1 << 8);

            //Debug.Log("hello " + Physics2D.GetLayerCollisionMask(0));
            //Physics2D.SetLayerCollisionMask(0, 0);
            //Debug.Log("hello " + Physics2D.GetLayerCollisionMask(0));

            //temporary solution until setlayercollision works
            //ignore everything >=8 that isn't this layer
            Physics2D.IgnoreLayerCollision(0, 8, false);

            Physics2D.IgnoreLayerCollision(0, 9, true);
            Physics2D.IgnoreLayerCollision(0, 10, true);
            Physics2D.IgnoreLayerCollision(0, 11, true);

            channelSound.Play();
        }

        //green = layer 9
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam.cullingMask = 127 | (1 << 9);

            Physics2D.IgnoreLayerCollision(0, 9, false);

            Physics2D.IgnoreLayerCollision(0, 8, true);
            Physics2D.IgnoreLayerCollision(0, 10, true);
            Physics2D.IgnoreLayerCollision(0, 11, true);

            channelSound.Play();
        }

        //blue = layer 10
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cam.cullingMask = 127 | (1 << 10);

            Physics2D.IgnoreLayerCollision(0, 10, false);

            Physics2D.IgnoreLayerCollision(0, 8, true);
            Physics2D.IgnoreLayerCollision(0, 9, true);
            Physics2D.IgnoreLayerCollision(0, 11, true);

            channelSound.Play();
        }

        //alpha = layer 11
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cam.cullingMask = 127 | (1 << 11);

            Physics2D.IgnoreLayerCollision(0, 11, false);

            Physics2D.IgnoreLayerCollision(0, 8, true);
            Physics2D.IgnoreLayerCollision(0, 9, true);
            Physics2D.IgnoreLayerCollision(0, 10, true);

            channelSound.Play();
        }
    }
}
