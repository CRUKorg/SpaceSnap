using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	public ParticleEmitter destroyEmitter;
	public AudioClip hitSound;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Asteroid"){
			if (gameObject.tag=="Player"){
				Debug.Log("Collision Detected");
				audio.PlayOneShot(hitSound);
				Destroy(col.gameObject);
				Instantiate (destroyEmitter, gameObject.transform.position, gameObject.transform.rotation);
				
				//GameObject.FindGameObjectWithTag("Player").audio.PlayOneShot(hitSound, volume);	
				//GameObject.FindGameObjectWithTag("Player").audio.PlayOneShot(cheerSound, 0.5f);
				//destroyAnimation(col.gameObject);
				//destroyAllObjects(gameObject.tag);
				//Destroy (col.gameObject);	//Destroy projectile
				//Destroy(gameObject);		//Destroy bin
				//GameplayScript.score+=3;
			}
		}
	}
	
	
	
}