using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	
	public Texture2D[] healthBar;
	public GUITexture theBar;
	private float theHealth;
	

	// Use this for initialization
	void Start () {
		theHealth = PlayerState.Health;
	}
	
	// Update is called once per frame
	void Update () {
		theHealth = PlayerState.Health;
		
		if (theHealth > 0) {
			int hp = (int)Mathf.Floor(theHealth/12.5f);
			if (hp > 7) hp=7;
			theBar.texture = healthBar[hp];
		}
		
		/*
		if ((theHealth <= 10.0f) && (theHealth >= 0.0f)){
			theBar.texture = null ; 
		}
		if ((theHealth <= 20.0f) && (theHealth > 10.0f)){
			theBar.texture = healthBar[0];
		}
		if ((theHealth <= 30.0f) && (theHealth > 20.0f)){
			theBar.texture = healthBar[1];
		}
		if ((theHealth <= 40.0f) && (theHealth > 30.0f)){
			theBar.texture = healthBar[2];
		}
		if ((theHealth <= 50.0f) && (theHealth > 40.0f)){
			theBar.texture = healthBar[3];
		}
		if ((theHealth <= 60.0f) && (theHealth > 50.0f)){
			theBar.texture = healthBar[3];
		}
		if ((theHealth <= 70.0f) && (theHealth > 60.0f)){
			theBar.texture = healthBar[4];
		}
		if ((theHealth <= 80.0f) && (theHealth > 70.0f)){
			theBar.texture = healthBar[5];
		}
		if ((theHealth <= 90.0f) && (theHealth > 80.0f)){
			theBar.texture = healthBar[6];
		}
		if (theHealth > 90.0f){
			theBar.texture = healthBar[7];
		}	
		*/	
	}
}
