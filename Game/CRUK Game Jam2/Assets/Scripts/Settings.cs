using UnityEngine;
using System.Collections;

public static class Settings {

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
	public static float CAMERA_DISTANCE_FROM_SHIP = 10.0F;	// default value for how far the camera is placed behind the ship
	
}
