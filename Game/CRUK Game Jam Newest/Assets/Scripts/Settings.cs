using UnityEngine;

using System.Collections;

public static class Settings {
	
	// Game Parameters
	public static float SHIP_ACCELERATION = 0.017f;			// the rate at which the game gradually speeds up over time
	public static float ASTEROID_START_DIFFERENCE = 100.0f;	// the distance at which the first asteroid spawns from the player
	
	
	// Ship Parameters
	public static float DEFAULT_THRUST = 10.0f;				// default velocity the ship moves through space
	public static float DEFAULT_HORIZONTAL_SPEED = 10.0f;	// default max speed of ship movement left/right
	public static float HORIZONTAL_ACCELERATION = 1.0f;		// acceleration applied when pressing left/right
	public static float HORIZONTAL_DAMPING = 0.75f;			// how fast the ship returns to resting horizontal velocity when left/right is not being pressed
	public static float DIRECTION_CHANGE_BOOST = 2.0f;		// a multiplier applied to the movement force when changing direction. The the lower this value, the harder the ship will be to control.
	public static float TURBO_BOOST_MAX = 2.0f;				// turbo bost multiplier. 0.2f has the boost increasing the ship's thrust by 20%
	public static float TURBO_FORCE = 1.0f;					// acceleration applied to thrust when boosting
	public static float TURBO_REST_DAMPING = 0.9f;			// damping applied when turbo boost stops being applied (the ship will return to previous thrust)
	public static float SHIP_SCREEN_PADDING = 0.1f;			// the amount of invisible padding added to the ship to stop it moving slightly past the screen edge
	public static int DEFAULT_SHIP_HEALTH = 5;				// set the ships health (how many asteroids it can collide with before dying)
	public static int MAX_SHIP_HEALTH = 999;				// maximum number of health points the ship can hold
	
	// Camera Parameters
	public static float CAMERA_DISTANCE_FROM_SHIP = 10.0f;	// default value for how far the camera is placed behind the ship (along the z axis)
	public static float CAMERA_HEIGHT = 3.5f;				// default value for how high the camera is placed above the ship (along the y axis)
	public static float SHIP_BOOST_OFFSET = 5.0f;			// how far the camera pushes back when boosting
	
	// Asteroid Parameters
	public static float ASTEROID_SPREAD = 2.0f;				// a multiplier used to scale the field the asteroids spawn in (how far they are spread apart on the x-axis)
	public static int ASTEROIDS_ON_SCREEN = 500;			// number of asteroids loaded at any time
	
	// Data
	public static float DATA_INTERVAL = 3.0f;				// every number of units along z that the ship's position is recorded
	
	
	// Debug
	public static bool SHOW_SHIP_DATA = false;				// true to print recorded ship data to the log
	
}
