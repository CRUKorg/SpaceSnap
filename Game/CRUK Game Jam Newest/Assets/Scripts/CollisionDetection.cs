using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	public ParticleEmitter destroyEmitter;
	public AudioClip hitSound;
	
	public AudioClip rewardSound;
	public ParticleEmitter rewardEmitter;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Asteroid"){
			if (gameObject.tag=="Player"){
				//Debug.Log("Collision Detected");
				audio.PlayOneShot(hitSound);
				PlayerState.DecrementHealth(5);
				PlayerState.Multiplier = 1;	
				Destroy(col.gameObject);
				SpawnAsteroid.instance.LoadNextAsteroid();
				Instantiate (destroyEmitter, gameObject.transform.position, gameObject.transform.rotation);
			}
		}
		
		if (col.gameObject.tag == "PowerUp1"){
			if (gameObject.tag=="Player"){
				audio.PlayOneShot(rewardSound);
				PlayerState.Score += 100 * PlayerState.Multiplier * Time.deltaTime/ 10;
				Instantiate (rewardEmitter, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(col.gameObject);
				SpawnPowerUps.instance.CreateNextPowerUp();
			}
		}
		if (col.gameObject.tag == "PowerUp2"){
			if (gameObject.tag=="Player"){
				audio.PlayOneShot(rewardSound);
				PlayerState.IncremeentHealth(20);	
				Instantiate (rewardEmitter, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(col.gameObject);
				SpawnPowerUps.instance.CreateNextPowerUp();
			}
		}
		if (col.gameObject.tag == "PowerUp3"){
			if (gameObject.tag=="Player"){
				audio.PlayOneShot(rewardSound);
				ShipController.thrust *= 0.8f;
				Instantiate (rewardEmitter, gameObject.transform.position, gameObject.transform.rotation);
				Destroy(col.gameObject);
				SpawnPowerUps.instance.CreateNextPowerUp();
			}
		}	
	}
	
	
	
	
}