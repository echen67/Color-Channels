using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    [Header("Enter the scene number of the scene you want to travel to")]
    public int SceneNum = 0;

    void OnTriggerEnter2D(Collider2D coll)
    {
            if(coll.gameObject.tag == "Player")
            {
                Debug.Log("Change Scene!");
                SceneManager.LoadScene(SceneNum);
            }
    }
}
