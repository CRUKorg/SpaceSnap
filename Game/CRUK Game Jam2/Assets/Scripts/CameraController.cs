using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform Ship;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 position = transform.position;
		position.z = Ship.position.z - Settings.CAMERA_DISTANCE_FROM_SHIP;
		transform.position = position;
	}
}
