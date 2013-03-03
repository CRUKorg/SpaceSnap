using UnityEngine;
using System.Collections;

public class GameOverSceenScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			Application.LoadLevel("RetryScene");
		}
		if (Input.touchCount > 0) {
			Application.LoadLevel("RetryScene");
		}	
	}
}
