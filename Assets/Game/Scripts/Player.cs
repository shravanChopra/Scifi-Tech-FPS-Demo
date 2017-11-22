using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private CharacterController _characterController;
	[SerializeField] private float _moveSpeed = 3.0f;
	[SerializeField] private float _gravity = 9.81f;
	// Use this for initialization
	void Start () 
	{
		_characterController = GetComponent<CharacterController>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalculateMovement();
	}

	void CalculateMovement()
	{
		// Compute move direction from user input
		float horizontalInput = Input.GetAxis("Horizontal");
		float verticalInput = Input.GetAxis("Vertical");
		Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

		// Move according to velocity, and apply gravity
		Vector3 velocity = direction * _moveSpeed;
		velocity.y -= _gravity;

		// transform velocity (and direction) to world space
		velocity = transform.TransformDirection(velocity);
		_characterController.Move(velocity * Time.deltaTime);		
	}
}
