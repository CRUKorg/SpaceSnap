using UnityEngine;
using System.Collections;


public class ShipController : MonoBehaviour {
	
	public Transform TheShip;
	public Camera TheCamera;
	
	private Vector3 thePosition;
	private Vector3 viewPosition;
	
	// boolean values to track inputs
	private bool isMovingRight;
	private bool isMovingLeft;
	private bool isBoosting;
	
	// ship movement speeds
	private float thrust;
	private float boostThrust;
	private float xVelocity;
	
	// screen boundaries
	private float leftBorder;
	private float rightBorder;
	
	public AudioClip boostOverSound;
	public AudioClip boostSound;
	
	// ship health
	private int health;		// store how many hits the ship can still take
	
	// Use this for initialization
	void Start () {
		thePosition = TheShip.position;
		thePosition.x = Screen.width/2;
		
		xVelocity = 0.0f;
		thrust = Settings.DEFAULT_THRUST;
		boostThrust = 0.0f;
		
		health = Settings.DEFAULT_SHIP_HEALTH;
	}
	
	// Update is called once per frame
	void Update () {
		
		viewPosition = TheCamera.WorldToViewportPoint(thePosition);
		
		thePosition = TheShip.position;
		
		GetInputs();
		HandleInputs();
		UpdatePosition();
		
		// need to add gradually increase ship thrust
		
		thePosition.z += (thrust + boostThrust)*Time.deltaTime;
		TheShip.position = thePosition;
		
		// apply rotation to ship based on x velocity
		Quaternion rot = new Quaternion();
		rot.eulerAngles = new Vector3(295, 180, xVelocity);
		transform.rotation = rot;

	}
	
	// decrement the ship's health by a specified number
	public void DecrementHealth(int damage) {
		health -= damage;
		
		// if health <= 0 kill ship
	}
	
	// increment the ship's health by a specified number (might be useful for powerups/score bonuses?)
	public void IncrementHealth(int health) {
		this.health += health;
		
		// limit hit points so they don't exceed the maximum allowed
		if (this.health > Settings.MAX_SHIP_HEALTH) {
			this.health = Settings.MAX_SHIP_HEALTH;
		}
	}
	
	public int GetHealth() {
		return health;
	}
	
	// check for inputs and set corrosponding boolean values appropriately
	private void GetInputs() {
		
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			isMovingRight = true;	
		}
		if(Input.GetKeyUp(KeyCode.RightArrow)){
			isMovingRight = false;	
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			isMovingLeft = true;	
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			isMovingLeft = false;	
		}	
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if (isBoosting = true){
				audio.PlayOneShot(boostSound);
				isBoosting = true;
			}	
		}
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			if(isBoosting = true){
				audio.PlayOneShot(boostOverSound);	
				isBoosting = false;
			}
		}
		
		
		
		if (Input.touchCount > 0) {
			Touch input = Input.touches[0];
			float x = input.position.x;
			
			Vector2 pos = TheCamera.WorldToScreenPoint(thePosition);
			
			if (x < pos.x) {
				isMovingLeft = true;
				isMovingRight = false;
			} else if (x > pos.x) {
				isMovingRight = true;
				isMovingLeft = false;
			} else {
				isMovingRight = false;
				isMovingLeft = false;
			}
		} else {
			isMovingRight = false;
			isMovingLeft = false;
		}
		
		
		
	}
	
	// process player inputs
	private void HandleInputs() {
		
		if (isMovingLeft || isMovingRight) {
			if(isMovingLeft){
				MoveLeft();	
			} else { // moving right
				MoveRight();	
			}
		} else { // not moving so should apply damping to stop ship from moving
			xVelocity *= Settings.HORIZONTAL_DAMPING;
		}
		
		if(isBoosting){
			Boost();
		} else {
			boostThrust *= Settings.TURBO_REST_DAMPING; // apply damping to cancel out boost when boost key is released
		}
	}
	
	// apply force to move the ship left (within the screen borders)
	private void MoveLeft(){
		
		float multipler = 1.0f;
		if (xVelocity > 0.0f) {
			multipler = 2.0f; // when changing direction, the ship is given a little boost to make the game play better
		}
		
		xVelocity -= Settings.HORIZONTAL_ACCELERATION * multipler;
		
		if (xVelocity < -Settings.DEFAULT_HORIZONTAL_SPEED) {
			xVelocity = -Settings.DEFAULT_HORIZONTAL_SPEED;
		}
	}
	
	// apply force to move the ship right
	private void MoveRight(){
		
		float multipler = 1.0f;
		if (xVelocity < 0.0f) {
			multipler = 2.0f;  // when changing direction, the ship is given a little boost to make the game play better
		}
		
		xVelocity += Settings.HORIZONTAL_ACCELERATION * multipler;
		
		if (xVelocity > Settings.DEFAULT_HORIZONTAL_SPEED) {
			xVelocity = Settings.DEFAULT_HORIZONTAL_SPEED;
		}
	}
	
	// update the ship's x position based on current velocity and constrain the ship to stay within the screen borders
	private void UpdatePosition() {
		
		// update position
		thePosition.x += xVelocity * Time.deltaTime;
		
		// keep the ship within the screen boundaries
		leftBorder = TheCamera.ViewportToWorldPoint(new Vector3(Settings.SHIP_SCREEN_PADDING, 0, Settings.CAMERA_DISTANCE_FROM_SHIP)).x;
		rightBorder = TheCamera.ViewportToWorldPoint(new Vector3(1-Settings.SHIP_SCREEN_PADDING, 0, Settings.CAMERA_DISTANCE_FROM_SHIP)).x;
		
		if (thePosition.x < leftBorder) {
			thePosition.x = leftBorder;
			xVelocity = 0.0f;
		}
		
		if (thePosition.x > rightBorder) {
			thePosition.x = rightBorder;
			xVelocity = 0.0f;
		}
	}
	
	private void Boost(){
		//thrust += thrust * Time.deltaTime ;
		boostThrust += Settings.TURBO_FORCE;
		
		if (boostThrust > CalcMaxBoost()) {
			boostThrust = CalcMaxBoost();
		}
	}
	
	private float CalcMaxBoost() {
		return thrust * Settings.TURBO_BOOST_MAX;
	}
	
	private void ResetSpeed(){
		thrust = Settings.DEFAULT_THRUST;
	}
	
	
}
