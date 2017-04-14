using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return : MonoBehaviour {

    public int sceneNum = 0;

	public void ReturnToMenu()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
