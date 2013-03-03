using UnityEngine;
using System.Collections;

public class RetryGameScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		 waitforseconds.wait(1);
	}
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel("Loading");
		}
		if (Input.touchCount > 0) {
			Application.LoadLevel("Loading");
		}
	}
}
