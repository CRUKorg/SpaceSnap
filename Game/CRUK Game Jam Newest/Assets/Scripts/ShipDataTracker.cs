using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipDataTracker : MonoBehaviour {
	
	public Transform TheShip;
	public Camera TheCamera;
	
	private float nextInterval; // the next z position that the data will be recorded for.
	public static List<Vector2> positions; // list of ship's positions at each interval
	
	// Use this for initialization
	void Start () {
		nextInterval = 0;
		positions = new List<Vector2>();
	}
	
	// Update is called once per frame
	void Update () {
		if (TheShip.position.z > nextInterval) { // if we have passed the data interval...
			// take the ships position and add it to the data list
			
			float xScale = TheCamera.ViewportToWorldPoint(new Vector3(1-Settings.SHIP_SCREEN_PADDING, 0, Settings.CAMERA_DISTANCE_FROM_SHIP)).x;
			float offsetX = (xScale * (Settings.ASTEROID_SPREAD-1))/2.0f;
			xScale *= Settings.ASTEROID_SPREAD;
			float x = (TheShip.position.x + offsetX)/xScale;
			
			float offsetZ = SpawnAsteroid.instance.offsetZ;
			
			positions.Add(new Vector2(x, TheShip.position.z-offsetZ));
			
			if (Settings.SHOW_SHIP_DATA) {
				Debug.Log ("Recorded position: " + TheShip.position.x + " (" + x + ") ; " + (TheShip.position.z-offsetZ));
			}
			
			nextInterval += Settings.DATA_INTERVAL;
		}	
	}
	
	public List<Vector2> GetShipData() {
		return positions;
	}
	
}
