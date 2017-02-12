using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour {
    
	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(PlayClicked);
	}
	
	void PlayClicked()
    {
        Debug.Log("Play");
    }

    void OnMouseDown()
    {
        Debug.Log("Play button clicked");
        SceneManager.LoadScene(0);
    }
}
