﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {

	[SerializeField] private float _sensitivity = 1f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// compute new rotation about Y
		float mouseX = Input.GetAxis("Mouse X");
		Vector3 newRotation = transform.localEulerAngles;
		newRotation.y += mouseX * _sensitivity;

		transform.localEulerAngles = newRotation;
	}
}
