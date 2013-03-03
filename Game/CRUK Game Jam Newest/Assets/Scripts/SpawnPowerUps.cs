using UnityEngine;
using System.Collections;

public class SpawnPowerUps : MonoBehaviour {
	public Rigidbody PowerUp1;
	public Rigidbody PowerUp2;
	public Rigidbody PowerUp3;
	
	public static SpawnPowerUps instance;
	public Transform TheShip;
	
	public enum PowerUpType{
		ReduceSize,
		IncreaseHealth,
		SlowDown,
	};
	public PowerUpType powerUpType;
	
	public Camera TheCamera;
	private Vector3 position;
	private Rigidbody instantiatedPowerUp;
	
	private float xScale;			// how much to scale the x coords of the powerups based on screen width
	private float offsetX;			// offset of powerup spawns to center them from xScale
	
	public static int numOfPowerUps;
	
	
	
	// Use this for initialization
	void Start () {
		instance = this;
		xScale = TheCamera.ViewportToWorldPoint(new Vector3(1-Settings.SHIP_SCREEN_PADDING, 0, Settings.CAMERA_DISTANCE_FROM_SHIP)).x;
		offsetX = (xScale * (Settings.ASTEROID_SPREAD-1))/2.0f;
		xScale *= 1.0f;
		numOfPowerUps = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (numOfPowerUps <= 2){
			CreateNextPowerUp();	
		}
	}
	
	public void CreateNextPowerUp(){
		numOfPowerUps++;
		
		float x = (Random.Range(0.0f, 1.0f) * xScale) - offsetX;
		float z = TheShip.position.z + Random.Range(200.0f, 500.0f);
		
		SpawnPowerUp(x, z);
		Debug.Log ("powerup spawned at : " + x + " ; " + z);
	}
	
	public void SpawnPowerUp(float x, float z){
		position = new Vector3(x, 0, z);
		Quaternion rot = new Quaternion(0, 0, 0, 0);
		int rand = Random.Range(1,4);
		if ( rand == 1){
			instantiatedPowerUp = Instantiate(PowerUp1, position, rot) as Rigidbody;	
			powerUpType = PowerUpType.ReduceSize;
		}
		if ( rand == 2){
			instantiatedPowerUp = Instantiate(PowerUp2, position, rot) as Rigidbody;
			powerUpType = PowerUpType.IncreaseHealth;
		}
		if (rand == 3){
			instantiatedPowerUp = Instantiate(PowerUp3, position, rot) as Rigidbody;
			powerUpType = PowerUpType.SlowDown;
		}
	}
}
