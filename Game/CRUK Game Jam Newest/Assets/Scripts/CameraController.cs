using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform Ship;
	
	public AudioClip boost;
	public AudioClip boostOver;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void AlignCameraToShip(float offsetZ) {
		Vector3 position = transform.position;
		position.z = Ship.position.z - Settings.CAMERA_DISTANCE_FROM_SHIP - offsetZ;
		position.y = Ship.position.y + Settings.CAMERA_HEIGHT;
		transform.position = position;
	}
	
}
