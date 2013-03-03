using UnityEngine;
using System.Collections;

public class DestroyAsteroid : MonoBehaviour {
	
	
	
	private float playerPos;
	private GameObject player;
	
	void Start(){
		player = GameObject.FindWithTag("Player");
		playerPos = player.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(gameObject.transform.position.z < player.transform.position.z - 3.0f){
			
			Destroy(gameObject);
		}	
		
		playerPos = player.transform.position.z;
	}
}
