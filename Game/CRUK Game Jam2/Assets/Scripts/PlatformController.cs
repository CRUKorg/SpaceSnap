using UnityEngine;
using System.Collections;

public class PlatformController : MonoBehaviour {
	
	/*
	public static CharacterController CharacterController;
	public static PlatformController Instance;
	bool faceingRight = true;
	
	private Vector3 initialPosition = Vector3.zero;
	private Quaternion initalRotation = Quaternion.identity;
	
	public bool Dead=false;
	
	private float dyingPoint = -5f;
	private float RespawnPoint = -20f;
	
	// Use this for initialization
	void Awake() {
		
		CharacterController = GetComponent("CharacterController") as CharacterController;
		Instance = this;
		CameraController.UseExistingOrCreateNewMainCamrea();
		initialPosition = transform.position;
		initalRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update() {
			if(Camera.mainCamera == null)
				return;
		GetMotionInput();
		PlatformMotor.Instance.UpdateMotor();

		PlatformMotor.Instance.ChangeOrientation(faceingRight);
		
		if(transform.position.y < dyingPoint){
			//play dying animation
			//restrict input
			Dead=true;
		}
		if(transform.position.y < RespawnPoint){
			Respawn ();
			Dead=false;
		}
	}
	
	void GetMotionInput(){
		float deadZone = 0.1f;
	//	PlatformMotor.Instance.VerticalVelocity = PlatformMotor.Instance.moveVector.y;
	//	PlatformMotor.Instance.moveVector = Vector3.zero;

		if(Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone){
			if(Input.GetAxis("Horizontal")>0){
				//move right
		//		PlatformMotor.Instance.moveVector += new Vector3(0,0,Input.GetAxis("Horizontal"));
				faceingRight = true;
			}
			if(Input.GetAxis("Horizontal")<0){
				//move left
		//		PlatformMotor.Instance.moveVector -= new Vector3(0,0,Input.GetAxis("Horizontal"));
				faceingRight = false;
			}
		}
	}
	void Respawn(){
		transform.position = initialPosition;
		transform.rotation = initalRotation;
	}
	*/
}
