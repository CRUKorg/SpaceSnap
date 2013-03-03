using UnityEngine;
using System.Collections;

//Emits particles from ship when boosting
public class ShipParticleEmitter : MonoBehaviour {
	
	public ParticleEmitter emitter;
	
	// Use this for initialization
	void Start () {
		Instantiate (emitter, gameObject.transform.position, gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
