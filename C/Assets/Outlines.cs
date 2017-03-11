using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outlines : MonoBehaviour {

	void Start () {
        Transform parentTrans = gameObject.transform.parent;

        gameObject.transform.localScale = new Vector2(parentTrans.lossyScale.x + 0.4f, parentTrans.localScale.y + .4f);
	}
}
