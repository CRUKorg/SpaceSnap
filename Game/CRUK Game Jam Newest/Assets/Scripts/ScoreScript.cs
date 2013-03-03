using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
	
	public GUIText scoreText;
	
	// Use this for initialization
	void Start () {
		Debug.Log("FINAL SCORE: " + PlayerState.Score);
		scoreText.text = "Final Score: " + PlayerState.Score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
