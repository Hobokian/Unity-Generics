using UnityEngine;
using System.Collections;

// Rigibody_Movement requires the GameObject to have a Rigidbody component
[RequireComponent (typeof (Rigidbody))]

public class Rigidbody_3rdPerson_Gamepad_Movement : MonoBehaviour {

	Rigidbody rb;
	public float rbDrag = 1f;
	public float speed = 25.0f;
	public float maxSpeed = 10.0f;
	public float turnSpeed = 3.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.drag = rbDrag;
	}

	void FixedUpdate () {
		transform.Rotate (0, Input.GetAxis ("Horizontal") * turnSpeed, 0);
		Vector3 forward = transform.TransformDirection (Vector3.forward);
		float verticalSpeed = speed * Input.GetAxis ("Vertical");
		// Move character
		verticalSpeed = Mathf.Clamp (verticalSpeed, -maxSpeed, maxSpeed);
		rb.AddForce (forward * verticalSpeed);
	}
}
