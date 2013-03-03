using UnityEngine;
using System.Collections;

public class PowerUpEffect : MonoBehaviour {
	
	public ParticleEmitter particles;
	
	// Use this for initialization
	void Start () {
		Instantiate (particles, gameObject.transform.position, gameObject.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
