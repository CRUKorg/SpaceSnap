using UnityEngine;
using System.Collections;

//Store scores, health etc of player
public class PlayerState : MonoBehaviour {
	
	private static int health;
	private static bool isAlive;
	private static float score;
	public static float Multiplier;
	
	private float counter;
	
	public ParticleEmitter deathAnimation;
	private bool deathAnimationPlayed;
	
	// Use this for initialization
	void Start () {
		health = 100; //Settings.MAX_SHIP_HEALTH;
		isAlive = true;
		score = 0;
		counter = 0;
		deathAnimationPlayed = false;
		Multiplier = 1;
	}
	
	// Update is called once per frame
	void Update () {
		//If player is dead, destroy and load game over scene
		if (health <= 0){
			if(deathAnimationPlayed == false){
				deathAnimationPlayed = true;
				Instantiate(deathAnimation, GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Player").transform.rotation);
			}			
			IsAlive = false;
			//Add delay between animation and destroy/load level
			Destroy(GameObject.FindGameObjectWithTag("Player"));
			Application.LoadLevel("GameOverScene");	
		}
		
		//If not dead, update score according to multiplier
		UpdateScore();
		//Debug.Log(score);
	}
	
	//Getters & Setters
	public static int Health{
		get { return health; } 
		set { health = value; }
	}
	
	public bool IsAlive{
		get { return isAlive; }
		set { isAlive = value; }
	}
/*	
	public float Score{
		get { return score; }
	}
	*/
	public static float Score{
		get { return score; }
		set { score = value;}
	}
	
	public static void DecrementHealth(int amount){
		health -= amount;
		//Debug.Log(health);
	}
	
	public static void IncremeentHealth(int amount){
		health+=amount;
		if(health>100){
			health = 100;	
		}
	}
	
	public static bool IsAliveCheck(){
		return isAlive;	
	}
	
	public void IncrementScore(int amount){
		score+=amount*Time.deltaTime;
	}
	
	public void UpdateScore(){
		score += Multiplier * Time.deltaTime / 10;
		Multiplier++;
	}
	
	
}
