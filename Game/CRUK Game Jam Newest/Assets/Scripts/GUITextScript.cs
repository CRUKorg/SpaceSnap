using UnityEngine;
using System.Collections;

public class GUITextScript : MonoBehaviour {
	
	public GUIText healthText;
	public GUIText scoreText;
	
	private int reformattedScore;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		reformattedScore = (int) PlayerState.Score;
		healthText.text = "Health: " + PlayerState.Health.ToString();
		scoreText.text = "Score: " + reformattedScore.ToString();
	}
	
	void OnGUI(){
			
	}
}
