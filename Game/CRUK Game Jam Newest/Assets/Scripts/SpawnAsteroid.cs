using UnityEngine;
using System.Collections;

public class SpawnAsteroid : MonoBehaviour {
	public Rigidbody Asteroid_Grey;
	public Rigidbody Asteroid_Blue;
	public Rigidbody Asteroid_Green;
	public Rigidbody Asteroid_Red;
	public Rigidbody Asteroid_Brown;
	
	public static SpawnAsteroid instance;
	
	
	public Camera TheCamera;
	
	private Vector3 position;
	private Rigidbody instantiatedAsteroid;
	
	private int asteroidDataIndex;	// store the index for the next asteroid to be loaded
	private float xScale;			// how much to scale the x coords of the asteroids based on screen width
	private float offsetX;			// offset of asteroid spawns to center them from xScale
	
	public float offsetZ;			// Z offset applied to asteroids. Updated to the last asteroids z position when the file loops so that new asteroids dont spawn way behind the player
	
	
	public enum AsteroidType{
		Grey,	//2 damage
		Blue,	//5 damage
		Green,	//10 damage
		Brown,
		Red
	};
	
	AsteroidType asteroidType;
	
	// Use this for initialization
	void Start () {
		instance = this;
		
		asteroidDataIndex = 0;
		xScale = TheCamera.ViewportToWorldPoint(new Vector3(1-Settings.SHIP_SCREEN_PADDING, 0, Settings.CAMERA_DISTANCE_FROM_SHIP)).x;
		offsetX = (xScale * (Settings.ASTEROID_SPREAD-1))/2.0f;
		offsetZ = -BackEndInterface2.positions[asteroidDataIndex].y + Settings.ASTEROID_START_DIFFERENCE;
		
		xScale *= Settings.ASTEROID_SPREAD;
		
		for (int i=0; i<Settings.ASTEROIDS_ON_SCREEN; i++) {
			LoadNextAsteroid();
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void LoadNextAsteroid() {
		if (asteroidDataIndex >= BackEndInterface2.positions.Count) {
			offsetZ += BackEndInterface2.positions[BackEndInterface2.positions.Count-1].y;
			asteroidDataIndex = 0;
			Debug.Log ("Level looped!");
		}
		
		CreateAsteroid((BackEndInterface2.positions[asteroidDataIndex].x * xScale) - offsetX, BackEndInterface2.positions[asteroidDataIndex].y + offsetZ);
		asteroidDataIndex++;
	}
	
	private void CreateAsteroid(float x, float z) {
		position = new Vector3(x, 0, z);
		Quaternion rot = new Quaternion(0, 0, 0, 0);
		//Instantiate an asteroid at set position in 3D space
		int rand = Random.Range(1,6);
		if ( rand == 1){
			instantiatedAsteroid = Instantiate(Asteroid_Grey, position, rot) as Rigidbody;	
			asteroidType = AsteroidType.Grey;
		}
		if ( rand == 2){
			instantiatedAsteroid = Instantiate(Asteroid_Blue, position, rot) as Rigidbody;
			asteroidType = AsteroidType.Blue;
		}
		if (rand == 3){
			instantiatedAsteroid = Instantiate(Asteroid_Green, position, rot) as Rigidbody;
			asteroidType = AsteroidType.Green;
		}
		if (rand == 4){
			instantiatedAsteroid = Instantiate(Asteroid_Brown, position, rot) as Rigidbody;
			asteroidType = AsteroidType.Brown;
		}
		if (rand == 5){
			instantiatedAsteroid = Instantiate(Asteroid_Red, position, rot) as Rigidbody;
			asteroidType = AsteroidType.Red;
		}
		
	}
	
	private void CreateAsteroid(Vector2 v) {
		CreateAsteroid(v.x, v.y);
	}
}

