using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControllerLowPolyFPSPack : MonoBehaviour {

	[Header("Cursor Lock")]
	public CursorLockMode cursor;

	[Header("Arms Object")]
	//Arm holder
	public Transform arms;

	[Header("Gun Camera")]
	//Gun camera
	[Tooltip("The main camera attached to the arms")]
	public Camera gunCamera;

	[Header("Run FOV Settings")]
	[Tooltip("The default field of view value")]
	//The default field of view value 
	public float defaultFOV = 55.0f;
	[Tooltip("The field of view value while running")]
	//Field of view value when running
	public float runFOV = 65.0f;
	//How fast the FOV changes
	[Tooltip("How fast the field of view value changes")]
	public float runFOVSpeed = 15.0f;

	[Header("Movement Settings")]
	//How fast the player moves
	[Tooltip("How fast the player walks")]
	public float movementSpeed = 4.0f;
	//Movement speed while running
	[Tooltip("How fast the player runs")]
	public float runSpeed = 7.0f;
	private float storedMovementSpeed;

	[Header("Mouse Look Settings")]
	//How fast the player rotates when moving mouse
	[Tooltip("How fast the player rotates when moving mouse around")]
	public float mouseLookSpeed = 3.0f;
	private Vector2 rotation = 
		new Vector2 (0,0);

	[Header("Mouse Look Clamp X Rotation")]
	//Clamp x rotation 
	//Minimum x rotation value
	[Tooltip("Minimum x rotation value (look up and down")]
	public float minXValue = -20.0f;
	//Maximum x rotation value
	[Tooltip("Maximum x rotation value (look up and down")]
	public float maxXValue = 20.0f;

	private void Start () 
	{
		//Save movement speed value
		storedMovementSpeed = movementSpeed;
	}

	private void Update () 
	{
		//Set cursor to selected state
		Cursor.lockState = cursor;

		//Movement
		//Move forward when holding down W key
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector3.forward * 
				movementSpeed * Time.deltaTime);
		}

		//Move backwards when holding down S key
		if (Input.GetKey (KeyCode.S)) 
		{
			transform.Translate (Vector3.back * 
				movementSpeed * Time.deltaTime);
		}

		//Strafe to the left when holding down A key
		if (Input.GetKey (KeyCode.A)) 
		{
			transform.Translate (Vector3.left * 
				movementSpeed * Time.deltaTime);
		}
		//Strafe to the right when holding down D key
		if (Input.GetKey (KeyCode.D)) 
		{
			transform.Translate (Vector3.right * 
				movementSpeed * Time.deltaTime);
		}

		//Run 
		//Run when holding down left shift key and pressing down W key
		if ((Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.LeftShift))) 
		{
			//Increase movement speed
			movementSpeed = runSpeed;
			//Lerp camera field of view 
			gunCamera.fieldOfView = Mathf.Lerp (gunCamera.fieldOfView,
				runFOV, runFOVSpeed * Time.deltaTime);
		} 
		else //If not running
		{
			//Set movement speed to normal
			movementSpeed = storedMovementSpeed;
			//Lerp back to default camera field of view
			gunCamera.fieldOfView = Mathf.Lerp(gunCamera.fieldOfView,
				defaultFOV,runFOVSpeed * Time.deltaTime);
		}
			
		//Mouse look
		//X input
		rotation.y += Input.GetAxis ("Mouse X");
		//Y input
		rotation.x -= Input.GetAxis ("Mouse Y");
		//Rotate on y axis based on mouse look speed
		transform.eulerAngles = new Vector2 
			(0, rotation.y) * mouseLookSpeed;
		//Clamp rotation on x axis to min and max values
		rotation.x = Mathf.Clamp (rotation.x, minXValue, maxXValue);
		//Rotate arms on the x axis
		arms.transform.localRotation = Quaternion.Euler 
			(rotation.x * mouseLookSpeed, 0, 0);
	}
}