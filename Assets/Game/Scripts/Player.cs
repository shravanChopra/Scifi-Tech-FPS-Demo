using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// movement
	private CharacterController _characterController;
	[SerializeField] private float _moveSpeed = 3.0f;
	[SerializeField] private float _gravity = 9.81f;

	// shooting
	private AudioSource _shootSound;
	private bool _isReloading = false;
	[SerializeField] private int _currentAmmo;
	[SerializeField] private int _maxAmmo = 50;
	
	// references to other GO's
	[SerializeField] private GameObject _muzzleFlash;
	[SerializeField] private GameObject _hitMarker;

	// reference to UI Manager
	private UIManager _uiManager;
	// Use this for initialization
	void Start () 
	{
		// get handles
		_characterController = GetComponent<CharacterController>();	
		_shootSound = GetComponent<AudioSource>();
		_uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

		// hide the mouse cursor
		Cursor.visible = false;
	
		// initialize ammo
		_currentAmmo = _maxAmmo;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetMouseButton(0) && _currentAmmo > 0)
		{
			Shoot();
		}
		else
		{
			_muzzleFlash.SetActive(false);
			_shootSound.Stop();
		}

		CalculateMovement();

		// if player presses Escape, show the mouse cursor
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Cursor.visible = true;
		}

		// reload
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (!_isReloading)
			{
				StartCoroutine(Reload());
				_isReloading = true;
			}
		}
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
	
	void Shoot()
	{
		// decrease ammo
		--_currentAmmo;
		_uiManager.UpdateAmmo(_currentAmmo);

		// play the muzzle flash
		_muzzleFlash.SetActive(true);

		// play the shoot sound
		_shootSound.Play();

		// cast ray from center of camera 
		Ray origin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hitInfo;

		// check what you hit
		if (Physics.Raycast(origin, out hitInfo))
		{	
			Debug.Log("Raycast hit " + hitInfo.transform.name);
			
			// create hitMarker and destroy after one second 
			GameObject hitMarker = Instantiate(_hitMarker, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
			Destroy(hitMarker, 1f);
		}
	}

	IEnumerator Reload()
	{
		yield return new WaitForSeconds(1.5f);
		_currentAmmo = _maxAmmo;
		_uiManager.UpdateAmmo(_currentAmmo);
		_isReloading = false;
	}
}
