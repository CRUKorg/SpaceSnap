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
		if(PlayerState.IsAliveCheck() == true){
			if(gameObject.transform.position.z < player.transform.position.z - 3.0f){
				
				Destroy(gameObject);
				SpawnAsteroid.instance.LoadNextAsteroid();
			}	
			
			playerPos = player.transform.position.z;
		}
	}
}
