using UnityEngine;
using System.Collections;

public class SpawnAsteroid : MonoBehaviour {
	public Rigidbody Asteroid_Grey;
	public Rigidbody Asteroid_Blue;
	public Rigidbody Asteroid_Green;
	
	private Vector3 position;
	private Rigidbody instantiatedAsteroid;
	
	public enum AsteroidType{
		Grey,	//2 damage
		Blue,	//5 damage
		Green,	//10 damage
	};
	
	AsteroidType asteroidType;
	
	// Use this for initialization
	void Start () {
		//CreateAsteroid(new Vector2(2.0f, 50.0f)); // Vector2 example
		
		for (int i=0; i<10; i++) {
			CreateAsteroid(Random.Range(0.0f, 10.0f), 50.0f + (i*10.0f));
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	private void CreateAsteroid(float x, float z) {
		position = new Vector3(x, 0, z);
		Quaternion rot = new Quaternion(0, 0, 0, 0);
		//Instantiate an asteroid at set position in 3D space
		int rand = Random.Range(1,4);
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
		
	}
	
	private void CreateAsteroid(Vector2 v) {
		CreateAsteroid(v.x, v.y);
	}
}

