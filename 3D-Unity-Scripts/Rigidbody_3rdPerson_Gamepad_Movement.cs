using UnityEngine;
using System.Collections;

// Rigibody_Movement requires the GameObject to have a Rigidbody component
[RequireComponent (typeof (Rigidbody))]

/// <summary>
/// This class controls a players movement applying forces to a Rigidbody component
/// This class can be used for 3D 3rd person gamepad/controller based games
/// </summary>
public class Rigidbody_3rdPerson_Gamepad_Movement : MonoBehaviour {

	Rigidbody rb; // Rigidbody component reference

	// Public variables
	public float rbDrag = 1f; // Rigidbody drag
	public float speed = 25.0f; // Player speed
	public float maxSpeed = 10.0f; // Player max speed
	public float turnSpeed = 3.0f; // Player turn speed

	/// <summary>
	/// Start is called first
	/// The function initializes all variables and components
	/// </summary>
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.drag = rbDrag;
	}

	/// <summary>
	/// FixedUpdate is called every physics step
	/// The function gets input from the user and adds a force to the Rigidbody component
	/// </summary>
	void FixedUpdate () {
		transform.Rotate (0, Input.GetAxis ("Horizontal") * turnSpeed, 0);
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		float verticalSpeed = speed * Input.GetAxis ("Vertical");
		verticalSpeed = Mathf.Clamp (verticalSpeed, -maxSpeed, maxSpeed);
		rb.AddForce (forward * verticalSpeed);
	}
}
